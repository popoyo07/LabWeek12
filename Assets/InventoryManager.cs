using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    PopulateInventory populate;
    public string itemName;
    public int itemID;
    bool searched;

    // Linear Search Method
     void LinearSearchByName(string itemName)
    {
        for (int i = 0; i < populate.InventoryItem.Count; i++)
        {
            if (populate.InventoryItem[i].Name == itemName)
            {
                Debug.Log($"Found using Linear Search item in ID# {populate.InventoryItem[i].ID} with the value of  {populate.InventoryItem[i].Value}"); // Return the index if the target is found
            }
        }
        Debug.Log($"Item is not in the list! -Linear search"); // Return the index if the target is found

    }

    // Binary Search Method
     void BinarySearchByID(int ID)
    {
        // sorts by id first
        populate.InventoryItem.Sort((a, b) => a.ID.CompareTo(b.ID));

        int left = 0;
        int right = populate.InventoryItem.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (populate.InventoryItem[mid].ID == ID)
            {
                Debug.Log($"Found using Binary Search item in ID# {populate.InventoryItem[mid].ID} named {populate.InventoryItem[mid].Name} with the value of  {populate.InventoryItem[mid].Value}"); // Return the index if the target is found
            }
            else if (populate.InventoryItem[mid].ID < ID)
            {
                left = mid + 1; // Narrow the search to the upper half
            }
            else
            {
                right = mid - 1; // Narrow the search to the lower half
            }
        }

        Debug.Log($"Item is not in the list! -Binary search"); // Return the index if the target is found
    }
  


    void Start()
    {
        populate = GetComponent<PopulateInventory>();

    }

    void Update()
    {
        if (itemName != "" && !searched)
        {
            LinearSearchByName(itemName);
            BinarySearchByID(itemID);
            PrintInventory("Sort By ID ");

            // Sort by Value (QuickSort)
            QuickSortByValue();
            PrintInventory("Quick Sort");
            searched = true;
        }
     
    }
    // QuickSort by Value
    void QuickSortByValue()
    {
        QuickSort(populate.InventoryItem, 0, populate.InventoryItem.Count - 1);
        Debug.Log("[QuickSort] Sorted inventory by Value!");
    }
    void QuickSort(List<InventoryItem> list, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high);
            QuickSort(list, low, pi - 1);
            QuickSort(list, pi + 1, high);
        }
    }
    int Partition(List<InventoryItem> items, int left, int right)
    {
        float pivot = items[right].Value;
        int smaller = left - 1;

        for (int j = left; j < right; j++)
        {
            if (items[j].Value < pivot)
            {
                smaller++;
                Swap(items, smaller, j);
            }
        }

        Swap(items, smaller + 1, right);
        return smaller + 1;
    }

    void Swap(List<InventoryItem> items, int a, int b)
    {
        InventoryItem temp = items[a];
        items[a] = items[b];
        items[b] = temp;
    }

    // Show the inventory
    void PrintInventory(string say)
    {
        Debug.Log($"--- {say} ---");
        foreach (var item in populate.InventoryItem)
        {
            Debug.Log($"ID: {item.ID}, Name: {item.Name}, Value: {item.Value}");
        }
        Debug.Log("--------------------------");
    }
}

