using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    void Start()
    {
        PlayerInventory playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnWallDestroyed.AddListener(DestroyWall);
        }
        
    }

    void OnDestroy()
    {
        PlayerInventory playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        playerInventory.OnWallDestroyed.RemoveListener(DestroyWall);
    }

    void DestroyWall()
    {
        Destroy(gameObject);
    }
}
