using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private float currentWeight = 0;
    private float maxWeight = 10;
    public List<GameObject> items;

    public GameObject newObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem();
        }
    }

    protected void AddItem()
    {
        ItemProperties script = newObject.GetComponent<ItemProperties>();
        float addedWeight = script.GetItemWeight();

        if ((addedWeight + currentWeight) <= maxWeight)
        {
            print("item picked up");

            currentWeight += addedWeight;
            items.Add(script.gameObject);
        }
        else
        {
            print("item to Heavy");
        }

        print(script.GetItemName());
    }

    protected void RemoveItem()
    {
        if (items.Count > 0)
        {
            ItemProperties script = items[0].GetComponent<ItemProperties>();
            float removedWeight = script.GetItemWeight();

            currentWeight -= removedWeight;

            items.Remove(script.gameObject);

            Debug.Log($"current weight:{currentWeight}");

            print(script.GetItemName());
        }
    }
}
