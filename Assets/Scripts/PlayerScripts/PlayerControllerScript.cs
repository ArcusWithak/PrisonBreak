using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private InventoryScript inventory;
    private Transform cameraTransfrom;


    [Header("Movement Speed")]
    public float speed = 5;

    [Space(10)]
    [Header("CameraTurning speed")]
    public float turnSpeed = 20;

    [Space(10)]
    [Header("max weight on game start")]
    public float initalMaxWeight;

    [Space(10)]
    [Header("range of picking up items")]
    public float pickUpRange;

    protected void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraTransfrom = transform.GetChild(0);

        inventory = new InventoryScript(initalMaxWeight);
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
                    Interaction(item.GetComponent<Iinteractable>());
                    break;
                }
            }
        }
    }

    public void Interaction(Iinteractable iinteractable)
    {
        iinteractable.action(this);
    }

    public bool AddItem(ItemProperties item)
    {
        return inventory.AddItem(item);
    }

    public bool OpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
    }
}
