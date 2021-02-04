using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : PickUp
{
    //properties
    public int bonuScore;

    //methods
    public override ItemProperties CreateItem()
    {
        return new BonusItem(itemName, itemWeight, bonuScore);
    }
}
