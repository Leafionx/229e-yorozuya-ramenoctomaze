using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class AnotherWallDestroyer : MonoBehaviour
{
    public int ramenNeeded = 0;
    public string textObjectName = "Intro";
    private PlayerInventory playerInventory;
    private bool wallDestroyed = false;

    void Start()
    {
        playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        
        if (playerInventory != null)
        {
            playerInventory.OnRamenCollected.AddListener(CheckRamenCount);
        }
    }

    void OnDestroy()
    {
        if (playerInventory != null)
        {
            playerInventory.OnRamenCollected.RemoveListener(CheckRamenCount);
        }
    }

    void CheckRamenCount(PlayerInventory playerInventory)
    {
        if (!wallDestroyed && playerInventory.NumberOfRamens == 0)
        {
            Destroy(gameObject);
            wallDestroyed = true;
            
            GameObject textObject = GameObject.Find(textObjectName);
            
            if (textObject != null)
            {
                Destroy(textObject);
            }
        }
    }
}
