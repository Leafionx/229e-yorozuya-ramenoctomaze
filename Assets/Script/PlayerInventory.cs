using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfRamens { get; private set; }
    public UnityEvent<PlayerInventory> OnRamenCollected;
    public UnityEvent OnWallDestroyed;

    public void RamenCollected()
    {
        NumberOfRamens++;
        OnRamenCollected.Invoke(this);
        
        if (NumberOfRamens >= 1)
        {
            DestroyWalls();
        }
    }

    void DestroyWalls()
    {
        OnWallDestroyed.Invoke();
    }
}
