using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPart : PickUp
{
    //methods
    public override ItemProperties CreateItem()
    {
        return new RaftItem(itemName, itemWeight);
    }
}
