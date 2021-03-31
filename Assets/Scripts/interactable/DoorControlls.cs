using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlls : MonoBehaviour, Iinteractable
{
    //properties
    public bool doorUnlocked = false;

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

    public void Action(PlayerControllerScript player)
    {
        if(!doorUnlocked)
        {
            if (player.OpenDoor(doorIndex))
            {
                doorUnlocked = true;
                open = !open;
            }
            else
            {
                player.GiveFeedBack("it's locked, have to find the key");
            }
        }
        else
        {
            open = !open;
        }
    }
}
