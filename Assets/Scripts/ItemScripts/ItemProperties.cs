using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProperties : MonoBehaviour
{
    protected string itemName;
    protected float itemWeight;

    public float GetItemWeight()
    {
        return itemWeight;
    }

    public abstract string GetItemName();
}
