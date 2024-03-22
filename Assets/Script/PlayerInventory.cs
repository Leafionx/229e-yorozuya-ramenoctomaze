using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfRamens { get; private set; }
    public UnityEvent<PlayerInventory> OnRamenCollected;

    public void RamenCollected()
    {
        NumberOfRamens++;
        OnRamenCollected.Invoke(this);
    }
}
