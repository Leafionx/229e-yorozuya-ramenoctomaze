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
        ramenText.text = playerInventory.NumberOfRamens.ToString();
    }

}
