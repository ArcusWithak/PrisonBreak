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
        if (open)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, startingRotationY + 90, 0), Time.deltaTime * 2.5f);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, startingRotation, Time.deltaTime * 2.5f);
        }
    }

    public void Action(PlayerControllerScript player)
    {
        if (!doorUnlocked)
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
