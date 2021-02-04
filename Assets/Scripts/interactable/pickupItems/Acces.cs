using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acces : PickUp
{
    //properties
    public int accesIndex;

    //methods
    public override ItemProperties CreateItem()
    {
        return new AccesItem(itemName, itemWeight, accesIndex);
    }
}
