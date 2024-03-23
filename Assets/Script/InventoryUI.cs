using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI ramenText;
    void Start()
    {
        ramenText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateRamenText(PlayerInventory playerInventory)
    {
        if (playerInventory.NumberOfRamens >= 0)
        {
            ramenText.text = playerInventory.NumberOfRamens.ToString();
        }
        else
        {
            ramenText.text = "0";
        }
    }

}
