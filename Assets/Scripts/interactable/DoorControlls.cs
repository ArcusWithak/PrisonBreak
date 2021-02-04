using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlls : MonoBehaviour, Iinteractable
{
    //properties
    public int doorIndex;

    //methods
    public void Start()
    {
        tag = "Interactable";
    }

    public void action(PlayerControllerScript player)
    {
        if (player.OpenDoor(doorIndex))
        {
            Destroy(this.gameObject);
        }
    }
}
