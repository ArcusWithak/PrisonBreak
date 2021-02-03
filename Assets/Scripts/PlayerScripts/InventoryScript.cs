using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private float currentWeight = 0;
    private float maxWeight = 10;
    public List<GameObject> items;

    public GameObject newObject;

    protected virtual bool AddItem()
    {
        ItemProperties script = newObject.GetComponent<ItemProperties>();

        print(script.GetItemName());

        if ((script.itemWeight + currentWeight) <= maxWeight)
        {
            print("item picked up");

            currentWeight += script.itemWeight;
            items.Add(newObject);

            return true;
        }
        else
        {
            print("item to Heavy");

            return false;
        }

    }

    protected virtual void RemoveItem()
    {
        if (items.Count > 0)
        {
            ItemProperties script = items[0].GetComponent<ItemProperties>();

            if (items.Remove(items[0]))
            {
                currentWeight -= script.itemWeight;

                Debug.Log($"current weight:{currentWeight}");
            }
            print(script.GetItemName());
        }
    }

    public float GetCurrentWeight()
    {
        return currentWeight;
    }

    public void DebugInventory()
    {
        print("=============================DEBUG INVENTORY====================================");
        print($"the inventory has {items.Count} items in it");
        print($"the weight is {currentWeight} kg out of a max of {maxWeight} kg");
    }
}
