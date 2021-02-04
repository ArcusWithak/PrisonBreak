using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : ItemProperties
{
    //properties
    public int bonusScore;

    //constructor
    public BonusItem(string itemName, float itemWeight, int bonusScore) : base(itemName, itemWeight)
    {
        this.bonusScore = bonusScore;
    }

    //methods
}
