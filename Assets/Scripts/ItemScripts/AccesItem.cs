using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : ItemProperties
{
    public int accesIndex;

    private void Start()
    {
        base.itemWeight = 1;
    }

    public override string GetItemName()
    {
        return "accesItem";
    }
}
