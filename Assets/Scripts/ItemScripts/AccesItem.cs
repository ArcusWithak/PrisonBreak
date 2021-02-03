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
    private void Start()
    {
        base.itemWeight = 1;
    }

    public override string GetItemName()
    {
        return "accesItem";
    }

    public bool OpensDoor(int id)
    {
        return accesIndex == id;
    }
}