using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : InventoryScript
{
    protected float speed = 5;
    private float turnSpeed = 5;

    private Transform camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        camera = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float speedH = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float speedV = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(speedH, 0, speedV);
        }

        //camera controls
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = -Input.GetAxis("Mouse Y");

        if (mouseInputX != 0)
        {
            mouseInputX *= turnSpeed;

            mouseInputX += transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, mouseInputX, transform.eulerAngles.z);
        }
        if(mouseInputY != 0)
        {
            mouseInputY *= turnSpeed;

            mouseInputY += camera.localEulerAngles.x;

            camera.localEulerAngles = new Vector3(Mathf.Clamp(mouseInputY, 0, 45), 0,0);
        }

        //inventory controlls
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem();
        }
    }









    protected override void AddItem()
    {
        base.AddItem();
    }

    protected override void RemoveItem()
    {
        base.RemoveItem();
    }
}
