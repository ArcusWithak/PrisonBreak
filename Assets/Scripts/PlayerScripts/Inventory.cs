using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    /// <summary>
    /// properties
    /// </summary>
    private float currentWeight = 0;
    private float maxWeight = 100;
    public List<ItemProperties> items = new List<ItemProperties>();

    public Inventory()
    {
        maxWeight = 100;
        items = new List<ItemProperties>();
        currentWeight = 0;
    }

    public Inventory(float maxWeight) : this ()
    {
        this.maxWeight = maxWeight;
    }

    /// <summary>
    /// methods
    /// </summary>
    /// <returns></returns>
    protected virtual void Start()
    {
        AddTestItem(new AccesItem("key of a little bit of doom", 10, 1));
        AddTestItem(new BonusItem("potato of the atheistic gods", 50, 50));
        AddTestItem(new BonusItem("globe of temporary sunlight", 50, 100));
        AddTestItem(new PuzzleItem("sticky riddle", 10, "stick", "what is brown and sticky?"));

        DebugInventory();

        TryDoor(1);
        TryDoor(2);
        TryRiddle("stick");
        TryRiddle("not a stick");
    }

    public bool AddItem(ItemProperties newItem)
    {
        if ((newItem.itemWeight + currentWeight) > maxWeight) { return false; }

        currentWeight += newItem.itemWeight;

        items.Add(newItem);

        return true;
    }

    public  bool RemoveItem(int ItemIndex)
    {
        ItemProperties newItem = items[ItemIndex];

        if (items.Count > 0)
        {
            if (items.Remove(newItem))
            {
                currentWeight -= newItem.itemWeight;

                return true;
            }
        }

        return false;
    }

    public float GetCurrentWeight()
    {
        return currentWeight;
    }

    public float GetMaxWeight()
    {
        return maxWeight;
    }

    public virtual bool CanOpenDoor(int id)
    {
        bool result = false;
        AccesItem key;

        foreach (ItemProperties item in items)
        {
            if (item is AccesItem)
            {
                key = (AccesItem)item;
                if (key.OpensDoor(id))
                {
                    result = true;
                    break;
                }
            }
        }

        return result;
    }

    public virtual bool CanAwnserRiddle(string awnser)
    {
        bool result = false;
        PuzzleItem riddle;

        foreach (ItemProperties item in items)
        {
            if (item is PuzzleItem)
            {
                riddle = (PuzzleItem)item;
                if (riddle.AwnserIsTo(awnser))
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
            Debug.Log(item.ToString());
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

    public void RemoveTestItem(int itemIndex)
    {
        if (RemoveItem(itemIndex))
        {
            Debug.Log($"item succesfully removed");
        }
        else
        {
            Debug.LogWarning($"item failed to remove");
        }
    }

    public void TryDoor(int id)
    {
        if (CanOpenDoor(id))
        {
            Debug.Log($"door {id} opend succesfully");
        }
        else
        {
            Debug.LogWarning($"door {id} failed to open");
        }
    }

    public void TryRiddle(string input)
    {
        if (CanAwnserRiddle(input))
        {
            Debug.Log($"{input} is the correct awnser to riddle");
        }
        else
        {
            Debug.LogWarning($"{input} is the wrong awnser to riddle");
        }
    }
}
