using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableChest : BreakAbleBaracade
{
    public GameObject storedObject;
    private bool empty = false;

    protected override void BreakObject(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

        if (collisionForce > 900)
        {
            if (!empty)
            {
                Instantiate(storedObject, transform.position + transform.forward + transform.up, Quaternion.identity);
                empty = true;
            }
            base.BreakObject(collision);
        }
    }
}
