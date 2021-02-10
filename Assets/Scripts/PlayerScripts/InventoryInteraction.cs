using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    [Space(10)]
    [Header("max weight on game start")]
    public float initalMaxWeight;

    protected InventoryScript inventory;

    public List<GameObject> inventoryItems;

    protected virtual void Start()
    {
        inventoryItems = new List<GameObject>();
        inventory = new InventoryScript(initalMaxWeight);
    }

    public virtual bool AddItem(GameObject itemObject, ItemProperties item = null)
    {
        inventoryItems.Add(itemObject);
        return true;
    }

    protected virtual void RemoveItem(int ItemIndex)
    {
        GameObject newItem = Instantiate(inventoryItems[ItemIndex], transform.position + (transform.forward * 2), Quaternion.identity);

        newItem.SetActive(true);

        inventoryItems.Remove(inventoryItems[ItemIndex]);
    }
}
