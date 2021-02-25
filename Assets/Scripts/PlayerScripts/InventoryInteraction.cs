using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInteraction : MonoBehaviour
{
    [Space(10)]
    [Header("max weight on game start")]
    public float initalMaxWeight;

    protected Inventory inventory;

    public List<GameObject> inventoryItems;

    private GameObject inventoryPanel;

    [Space(10)]
    [Header("the button prefab for ui")]
    public GameObject Uipiece;

    protected virtual void Start()
    {
        inventoryItems = new List<GameObject>();
        inventory = new Inventory(initalMaxWeight);

        inventoryPanel = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
    }

    public virtual bool AddItem(GameObject itemObject, ItemProperties item = null)
    {
        inventoryItems.Add(itemObject);
        itemObject.SetActive(false);
        return true;
    }

    public virtual void RemoveItem(int ItemIndex)
    {
        inventoryItems[ItemIndex].transform.position = transform.position + (transform.forward * 2);
        inventoryItems[ItemIndex].transform.rotation = Quaternion.identity;
        inventoryItems[ItemIndex].SetActive(true);

        inventoryItems[ItemIndex].GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 100, 0) + (transform.forward * 1000), transform.position);

        inventoryItems.Remove(inventoryItems[ItemIndex]);

        UpdateInventoryUi();
    }

    protected void OpenCloseInventoryUi()
    {
        inventoryPanel.gameObject.SetActive(!inventoryPanel.activeSelf);

        UpdateInventoryUi();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void UpdateInventoryUi()
    {
        inventoryPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"weight:{inventory.GetCurrentWeight()}/{inventory.GetMaxWeight()}";

        for (int i = inventoryPanel.transform.childCount; i > 1; i--)
        {
            inventoryPanel.transform.GetChild(i - 1).gameObject.SetActive(false);
        }

        for (int i = 1; i < inventoryItems.Count + 1; i++)
        {
            inventoryPanel.transform.GetChild(i).gameObject.SetActive(true);

            inventoryPanel.transform.GetChild(i).gameObject.GetComponent<Text>().text = inventory.items[i - 1].itemName;
        }
    }
}