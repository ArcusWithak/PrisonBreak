using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private float currentWeight = 0;
    private float maxWeight = 10;
    public List<GameObject> items;

    public GameObject newObject;

    protected virtual void AddItem()
    {
        ItemProperties script = newObject.GetComponent<ItemProperties>();
        float addedWeight = script.itemWeight;

        if ((addedWeight + currentWeight) <= maxWeight)
        {
            print("item picked up");

            currentWeight += addedWeight;
            items.Add(newObject);
        }
        else
        {
            print("item to Heavy");
        }

        print(script.GetItemName());
    }

    protected virtual void RemoveItem()
    {
        if (items.Count > 0)
        {
            ItemProperties script = items[0].GetComponent<ItemProperties>();
            float removedWeight = script.itemWeight;

            currentWeight -= removedWeight;

            items.Remove(items[0]);

            Debug.Log($"current weight:{currentWeight}");

            print(script.GetItemName());
        }
    }
}
