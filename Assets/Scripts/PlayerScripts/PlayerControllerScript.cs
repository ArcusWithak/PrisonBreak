using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : InventoryInteraction
{
    private Transform cameraTransfrom;
    private Rigidbody rB;

    [Header("Movement Speed")]
    public float speed = 5;

    [Space(10)]
    [Header("CameraTurning speed")]
    public float turnSpeed = 20;

    [Space(10)]
    [Header("range of picking up items")]
    public float pickUpRange;

    public Text feedbackText;

    protected override void Start()
    {
        base.Start();

        Cursor.lockState = CursorLockMode.Locked;
        cameraTransfrom = transform.GetChild(0);
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
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
                        Vector3 direction = item.transform.position - transform.position;

                        if (Vector3.Angle(direction, transform.forward) < 45)
                        {
                            RaycastHit hit;
                            if (Physics.Raycast(transform.position, direction, out hit, pickUpRange, LayerMask.GetMask("interactable")))
                            {
                                if (hit.transform.CompareTag("Interactable") && hit.transform.gameObject == item.gameObject)
                                {
                                    Interaction(item.GetComponent<Iinteractable>());
                                    break;
                                }
                                else
                                {
                                    print(hit.transform.tag);
                                }
                            }
                        }
                    }
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventoryItems.Count > 0)
            {
                RemoveItem(inventoryItems.Count - 1);
            }
            else
            {
                print("inventory empty");
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventoryUi();
        }

        if(transform.position.y < 15 && transform.position.y > 0)
        {
            rB.AddForceAtPosition((-Physics.gravity / (transform.position.y / 5f)), transform.position + -transform.up, ForceMode.Force);
        }
    }

    public void Interaction(Iinteractable interactable)
    {
        interactable.Action(this);
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

    public void OpenRiddle(string riddle, string awnser)
    {
        OpenCloseRiddlePanel(riddle, awnser);
    }

    public void RiddleInput()
    {
        riddleAwnsered = true;
    }

    public bool CheckRiddle()
    {
        string awnser = GetRiddleInput();
        return awnser == riddleAwnser;
    }

    public override void RemoveItem(int ItemIndex, bool throwObject)
    {
        if (inventory.RemoveItem(ItemIndex))
        {
            base.RemoveItem(ItemIndex, throwObject);
        }
    }

    public override void RemoveItem(int ItemIndex)
    {
        if (inventory.RemoveItem(ItemIndex))
        {
            base.RemoveItem(ItemIndex);
        }
    }

    public void GiveFeedBack(string feedback)
    {
        feedbackText.text = feedback;
        StartCoroutine(ResetText());
    }

    private IEnumerator ResetText()
    {
        yield return new WaitForSeconds(10);
        feedbackText.text = "";
    }
}
