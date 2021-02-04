using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlls : MonoBehaviour, Iinteractable
{
    //properties
    public int doorIndex;
    private bool open;
    private Vector3 startingRotation;

    //methods
    public void Start()
    {
        startingRotation = transform.rotation.eulerAngles;
        tag = "Interactable";
    }

    public void action(PlayerControllerScript player)
    {
        if (player.OpenDoor(doorIndex))
        {
            if (open)
            {
                open = false;
                transform.eulerAngles = startingRotation;
            }
            else
            {
                open = true;
                transform.eulerAngles = startingRotation + new Vector3(0, 90, 0);
            }
        }
    }
}
