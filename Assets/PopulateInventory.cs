using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
   [SerializeField] public List<InventoryItem> InventoryItem = new List<InventoryItem>();
   [SerializeField] private int id;
   [SerializeField] private string n;
   [SerializeField] private int value;

    public List<InventoryItem> FilterItemsByValueRange(int minValue, int maxValue)
    {
        List<InventoryItem> filteredItems = new List<InventoryItem>();

        for (int i = 0; i< InventoryItem.Count; i++)
        {
            if (InventoryItem[i].Value >= minValue && InventoryItem[i].Value <= maxValue)
            {
                filteredItems.Add(InventoryItem[i]);
            }
        }
      
        return filteredItems;
    }
    public int CalculateTotalInventoryValue()
    {
        int totalVlaue = 0;
        for (int i = 0; i < InventoryItem.Count; i++)
        {
            totalVlaue += InventoryItem[i].Value;
        }
        Debug.LogWarning(totalVlaue);
        return totalVlaue;
    }
    void Awake()
    {
        int r = Random.Range(100, 1000);
        for (int i = 0; i < r; i++)
        {
            // generates random ingo 
            int randomID = Random.Range(i, r + 1);
            string randomName = "name " + i;
            int randomValue = Random.Range(1, 10000000);

            // adds random info to the class instance and add to list 
            InventoryItem newItem = new InventoryItem(randomID, randomName, randomValue);
            InventoryItem.Add(newItem);
            Debug.Log($"Added the inventory item {newItem.ID} ID and {newItem.Name} and {newItem.Value}");
        }

        AddItemToInventory(id, n, value);
        Debug.LogWarning("running");
        Debug.LogWarning(CalculateTotalInventoryValue());
    }
 
    public void AddItemToInventory(int id, string name, int value)
    {
        InventoryItem newItem = new InventoryItem(id, name, value);
        InventoryItem.Add(newItem);
        Debug.LogWarning($"Added {newItem} ID {id}, name {name}, value {value}");
    }
}
