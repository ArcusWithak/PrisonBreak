using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : ItemProperties
{
    //properties
    public int accesIndex;

    //methods
    private void Start()
    {
        base.itemWeight = 1;
    }

    public override string GetItemName()
    {
        return "accesItem";
    }
}
