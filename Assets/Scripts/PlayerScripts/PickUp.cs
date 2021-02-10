﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour, Iinteractable
{
    //properties
    public string itemName;
    public float itemWeight;

    //methods
    public void Start()
    {
        tag = "Interactable";
    }

    public void action(PlayerControllerScript player)
    {
        if (player.AddItem(this.gameObject, CreateItem()))
        {
            gameObject.SetActive(false);
        }
    }

    public abstract ItemProperties CreateItem();
}
