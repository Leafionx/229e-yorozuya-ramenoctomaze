using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActive : MonoBehaviour
{
    public int damageAmount = 10;
    private PlayerHealth playerHealth;
    public float rollSpeed = 5f;
    public float maxDistance = 10f;
    public float bounceForce = 10f; 

    private Vector3 initialPosition;
    private bool isBouncingBack = false;

    private Rigidbody rb;

    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (!isBouncingBack)
        {
            transform.Translate(Vector3.forward * rollSpeed * Time.deltaTime);
            
            Vector3 movement = transform.forward * rollSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, initialPosition, rollSpeed * Time.deltaTime));
            
            if (Vector3.Distance(rb.position, initialPosition) < 0.1f)
            {
                isBouncingBack = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(10);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 direction = Vector3.Reflect(transform.forward, normal);
            
            GetComponent<Rigidbody>().AddForce(direction * bounceForce, ForceMode.Impulse);
            rb.AddForce(direction * bounceForce, ForceMode.Impulse);
            
            isBouncingBack = true;
        }
    }
}
