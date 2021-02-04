using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    /// <summary>
    /// properties
    /// </summary>
    private float currentWeight = 0;
    private float maxWeight = 100;
    public List<ItemProperties> items;

    /// <summary>
    /// methods
    /// </summary>
    /// <returns></returns>
    protected virtual void Start()
    {
        items = new List<ItemProperties>();
        AddTestItem(new AccesItem("key of a little bit of doom", 10, 1));
        AddTestItem(new BonusItem("potato of the atheistic gods", 50, 50));
        AddTestItem(new BonusItem("globe of temporary sunlight", 50, 100));
    }

    protected virtual bool AddItem(ItemProperties newItem)
    {
        if ((newItem.itemWeight + currentWeight) <= maxWeight)
        {
            currentWeight += newItem.itemWeight;
            print(newItem);
            items.Add(newItem);

            Debug.Log("item picked up");

            return true;
        }
        else
        {
            Debug.Log("item to Heavy");

            return false;
        }

    }

    protected virtual bool RemoveItem(ItemProperties newItem)
    {
        if (items.Count > 0)
        {
            if (items.Remove(newItem))
            {
                currentWeight -= newItem.itemWeight;

                Debug.Log($"current weight:{currentWeight}");

                return true;
            }
            Debug.Log(newItem.GetItemName());
        }

        return false;
    }

    public float GetCurrentWeight()
    {
        return currentWeight;
    }


    public virtual bool CanOpenDoor(int id)
    {
        bool result = false;
        AccesItem script;

        foreach (ItemProperties item in items)
        {
            if (item is AccesItem)
            {
                script = (AccesItem)item;
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
        foreach (ItemProperties item in items)
        {
            Debug.Log($"{item.itemName} is in the inventory with a weight of: {item.itemWeight}");
        }
    }

    public void AddTestItem(ItemProperties item)
    {
        if (AddItem(item))
        {
            Debug.Log($"{item.itemName} added to inventory");
        }
        else
        {
            Debug.LogWarning($"{item.itemName} failed to get added to inventory");
        }
    }

    public void RemoveTestItem(ItemProperties item)
    {
        if (RemoveItem(item))
        {
            Debug.Log($"{item.itemName} succesfully removed");
        }
        else
        {
            Debug.LogWarning($"{item.itemName} failed to remove");
        }
    }
}
