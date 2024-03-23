using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class AnotherWallDestroyer : MonoBehaviour
{
    public int ramenNeeded = 1;
    public string textObjectName = "Intro";

    void Start()
    {
        PlayerInventory playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        
        if (playerInventory != null)
        {
            playerInventory.OnRamenCollected.AddListener(CheckRamenCount);
        }
    }

    void OnDestroy()
    {
        PlayerInventory playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnRamenCollected.RemoveListener(CheckRamenCount);
        }
    }

    void CheckRamenCount(PlayerInventory playerInventory)
    {
        if (playerInventory.NumberOfRamens >= ramenNeeded)
        {
            Destroy(gameObject);
            
            GameObject textObject = GameObject.Find(textObjectName);
            
            if (textObject != null)
            {
                Destroy(textObject);
            }
        }
    }
}
