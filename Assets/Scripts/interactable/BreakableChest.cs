using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableChest : BreakAbleBaracade
{
    public GameObject storedObject;

    protected override void BreakObject(Collision collision)
    {
        base.BreakObject(collision);
        Instantiate(storedObject, transform.position + transform.forward + transform.up, Quaternion.identity);
    }
}
