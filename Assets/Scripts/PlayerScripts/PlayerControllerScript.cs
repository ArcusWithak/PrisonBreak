using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : InventoryScript
{
    protected float speed = 5;
    private float turnSpeed = 20;

    private Transform cameraTransfrom;

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

    //    //inventory controlls
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        AddItem();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        RemoveItem();
    //    }
    }

    //protected override bool AddItem()
    //{
    //    return base.AddItem();
    //}

    //protected override void RemoveItem()
    //{
    //    base.RemoveItem();
    //}
}
