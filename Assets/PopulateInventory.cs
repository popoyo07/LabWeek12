using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    public List<InventoryItem> InventoryItem = new List<InventoryItem>();


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
    }


}
