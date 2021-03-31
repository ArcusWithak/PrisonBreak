using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : itemPhysicProperties, Iinteractable
{
    //properties
    public string itemName;
    public float itemWeight;

    //methods
    public override void Start()
    {
        tag = "Interactable";
        base.Start();
    }

    public void Action(PlayerControllerScript player)
    {
        player.AddItem(this.gameObject, CreateItem());
    }

    public abstract ItemProperties CreateItem();
}
