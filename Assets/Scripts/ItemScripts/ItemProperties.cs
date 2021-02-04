using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProperties
{
    //properties
    public string itemName{ protected set; get; }
    public float itemWeight{ protected set; get;}

    //constructor
    public ItemProperties(string itemName, float itemWeight)
    {
        this.itemName = itemName;
        this.itemWeight = itemWeight;
    }

    //methods
    public override string ToString()
    {
        return $"type is: {base.ToString()}| name is: {itemName}| weight is {itemWeight}";
    }
}
