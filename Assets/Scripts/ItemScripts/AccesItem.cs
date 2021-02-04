using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : ItemProperties
{
    //properties
    public int accesIndex;

    //constructor
    public AccesItem(string itemName, float itemWeight, int accesIndex) : base(itemName, itemWeight)
    {
        this.accesIndex = accesIndex;
    }

    //methods
    public override string GetItemName()
    {
        return itemName;
    }

    public bool OpensDoor(int id)
    {
        return accesIndex == id;
    }
}