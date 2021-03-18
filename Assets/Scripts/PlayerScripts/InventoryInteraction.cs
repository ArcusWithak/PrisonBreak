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

    private GameObject riddlePanel;
    protected string riddleAwnser;
    public bool riddleAwnsered;

    [Space(10)]
    [Header("the button prefab for ui")]
    public GameObject Uipiece;

    protected virtual void Start()
    {
        inventoryItems = new List<GameObject>();
        inventory = new Inventory(initalMaxWeight);

        inventoryPanel = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        riddlePanel = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
    }

    public virtual bool AddItem(GameObject itemObject, ItemProperties item = null)
    {
        inventoryItems.Add(itemObject);
        itemObject.SetActive(false);
        return true;
    }

    public virtual void RemoveItem(int ItemIndex, bool throwObject = true)
    {
        if (throwObject)
        {
            inventoryItems[ItemIndex].transform.position = transform.position + (transform.forward * 2);
            inventoryItems[ItemIndex].transform.rotation = Quaternion.identity;
            inventoryItems[ItemIndex].SetActive(true);

            inventoryItems[ItemIndex].GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 100, 0) + (transform.forward * 1000), transform.position);
        }

        inventoryItems.Remove(inventoryItems[ItemIndex]);

        UpdateInventoryUi();
    }

    public List<GameObject> AddRaftParts()
    {
        List<GameObject> value = new List<GameObject>();

        int i = 0;

        foreach (int index in inventory.CheckForRaftParts())
        {
            value.Add(inventoryItems[index - i]);
            RemoveItem(index - i, false);
            i++;
        }

        return value;
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

    protected void OpenCloseRiddlePanel(string riddle, string awnser)
    {
        riddlePanel.gameObject.SetActive(!riddlePanel.activeSelf);

        riddlePanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = riddle;

        riddleAwnser = awnser;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    protected string GetRiddleInput()
    {
        return riddlePanel.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>().text;
    }

    public void CloseRiddle()
    {
        riddlePanel.gameObject.SetActive(!riddlePanel.activeSelf);

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}