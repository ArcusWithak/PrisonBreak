using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        itemObject.SetActive(false);
        return true;
    }

    protected virtual void RemoveItem(int ItemIndex)
    {
        inventoryItems[ItemIndex].transform.position = transform.position + (transform.forward * 2);
        inventoryItems[ItemIndex].transform.rotation = Quaternion.identity;
        inventoryItems[ItemIndex].SetActive(true);

        inventoryItems.Remove(inventoryItems[ItemIndex]);
    }
}