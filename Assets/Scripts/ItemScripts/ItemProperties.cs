using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProperties
{
    //properties
    public string itemName
    {
        protected set;

        get;
    }
    public float itemWeight
    {
        protected set;

        get;
    }

    //methods
    public float GetItemWeight()
    {
        return itemWeight;
    }

    public abstract string GetItemName();
}
