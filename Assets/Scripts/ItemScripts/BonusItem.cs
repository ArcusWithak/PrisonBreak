using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : ItemProperties
{
    public int bonusScore;

    private void Start()
    {
        base.itemWeight = 1;
    }

    public override string GetItemName()
    {
        base.itemName = "bonusItem";
        return base.itemName;
    }
}
