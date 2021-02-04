using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    /// <summary>
    /// properties
    /// </summary>
    private float currentWeight = 0;
    private float maxWeight = 10;
    public List<GameObject> items;

    public GameObject newObject;

    /// <summary>
    /// methods
    /// </summary>
    /// <returns></returns>
    protected virtual bool AddItem()
    {
        ItemProperties script = newObject.GetComponent<ItemProperties>();

        Debug.Log(script.GetItemName());

        if ((script.itemWeight + currentWeight) <= maxWeight)
        {
            Debug.Log("item picked up");

            currentWeight += script.itemWeight;
            items.Add(newObject);

            return true;
        }
        else
        {
            Debug.Log("item to Heavy");

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
            Debug.Log(script.GetItemName());
        }
    }

    public float GetCurrentWeight()
    {
        return currentWeight;
    }


    public virtual bool CanOpenDoor(int id)
    {
        bool result = false;
        AccesItem script;

        foreach (GameObject item in items)
        {
            script = item.GetComponent<AccesItem>();
            if (script != null)
            {
                if (script.OpensDoor(id))
                {
                    result = true;
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Debuggin methods
    /// </summary>
    public void DebugInventory()
    {
        Debug.Log("=============================DEBUG INVENTORY====================================");
        Debug.Log($"the inventory has {items.Count} items in it");
        Debug.Log($"the weight is {currentWeight} kg out of a max of {maxWeight} kg");
    }
}
