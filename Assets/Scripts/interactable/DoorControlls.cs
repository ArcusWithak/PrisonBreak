using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlls : MonoBehaviour, Iinteractable
{
    //properties
    public int doorIndex;
    private bool open;
    private Quaternion startingRotation;
    private float startingRotationY;

    //methods
    public void Start()
    {
        startingRotation = transform.rotation;
        startingRotationY = transform.rotation.y;
        tag = "Interactable";
    }

    private void Update()
    {
        if (!open && transform.eulerAngles.y < startingRotationY + 90)
        {
            transform.rotation = Quaternion.RotateTowards(startingRotation, Quaternion.Euler(0, startingRotationY + 90, 0), 1);
        }
        else if (open && transform.eulerAngles.y > startingRotationY)
        {
            transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0, startingRotationY + 90, 0), startingRotation, 1);
        }
    }

    public void action(PlayerControllerScript player)
    {
        if (player.OpenDoor(doorIndex))
        {
            open = !open;
        }
        else
        {
            player.GiveFeedBack("it's locked, have to find the key");
        }
    }
}
