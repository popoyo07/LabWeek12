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

    public static void Sorting(string[] args)
    {

        QuickSort quickSortObject = new QuickSort();

        int[] array = { 1, 4, 2, 5, 3 };

        quickSortObject.quickSort(array, 0, array.Length - 1);

    }
    void Start()
    {
        populate = GetComponent<PopulateInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (itemName != "" && !searched)
        {
            LinearSearchByName(itemName);
            BinarySearchByID(itemID);

            searched = true;
        }
     
    }
}
class QuickSort
{

    public int partition(int[] array, int first, int last)
    {
        int pivot = array[last];
        int smaller = (first - 1);

        for (int element = first; element < last; element++)
        {
            if (array[element] < pivot)
            {
                element++;

                int temporary = array[smaller];
                array[smaller] = array[element];
                array[element] = temporary;
            }
        }

        int temporaryNext = array[smaller + 1];
        array[smaller + 1] = array[last];
        array[last] = temporaryNext;

        return smaller + 1;

    }

    public void quickSort(int[] array, int first, int last)
    {
        if (first < last)
        {
            int pivot = partition(array, first, last);

            quickSort(array, first, pivot - 1);
            quickSort(array, pivot + 1, last);

        }
    }
}

class MainClass
{
    public static void Main(string[] args)
    {

        QuickSort quickSortObject = new QuickSort();

        int[] array = { 1, 4, 2, 5, 3 };

        quickSortObject.quickSort(array, 0, array.Length - 1);

    }
}
