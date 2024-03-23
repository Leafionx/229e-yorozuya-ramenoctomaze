using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfRamens  { get; private set; }
    public UnityEvent<PlayerInventory> OnRamenCollected;
    public UnityEvent OnWallDestroyed;

    void Start()
    {
        NumberOfRamens = -1;
    }

    public void RamenCollected()
    {
        NumberOfRamens++;
        OnRamenCollected.Invoke(this);
        
        if (NumberOfRamens >= 10)
        {
            DestroyWalls();
        }
    }

    void DestroyWalls()
    {
        OnWallDestroyed.Invoke();
    }
}
