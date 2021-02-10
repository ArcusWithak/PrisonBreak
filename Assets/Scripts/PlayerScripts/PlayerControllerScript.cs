using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : InventoryInteraction
{
    private Transform cameraTransfrom;


    [Header("Movement Speed")]
    public float speed = 5;

    [Space(10)]
    [Header("CameraTurning speed")]
    public float turnSpeed = 20;

    [Space(10)]
    [Header("range of picking up items")]
    public float pickUpRange;

    protected override void Start()
    {
        base.Start();

        Cursor.lockState = CursorLockMode.Locked;
        cameraTransfrom = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float speedH = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float speedV = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(speedH, 0, speedV);
        }

        //camera controls
        float mouseInputY = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseInputX = -Input.GetAxis("Mouse Y") * turnSpeed;

        if (mouseInputY != 0)
        {
            mouseInputY += transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, mouseInputY, transform.eulerAngles.z);
        }

        if (mouseInputX != 0)
        {
            mouseInputX += cameraTransfrom.rotation.eulerAngles.x;

            cameraTransfrom.rotation = Quaternion.Euler(Mathf.Clamp(mouseInputX, 0, 45), cameraTransfrom.eulerAngles.y, cameraTransfrom.eulerAngles.z);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpRange);
            foreach (Collider item in colliders)
            {
                if (item.CompareTag("Interactable"))
                {
                    if (Vector3.Angle(transform.forward, item.gameObject.transform.position) < 45)
                    {
                        Interaction(item.GetComponent<Iinteractable>());
                        break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventoryItems.Count > 0)
            {
                RemoveItem(0);
            }
            else
            {
                print("inventory empty");
            }
        }
    }

    public void Interaction(Iinteractable interactable)
    {
        interactable.action(this);
    }

    public override bool AddItem(GameObject itemObject, ItemProperties item = null)
    {
        if (inventory.AddItem(item))
        {
            return base.AddItem(itemObject);
        }
        return false;
    }

    public bool OpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
    }

    protected override void RemoveItem(int ItemIndex)
    {
        if (inventory.RemoveItem(ItemIndex))
        {
            base.RemoveItem(ItemIndex);
        }
    }
}
