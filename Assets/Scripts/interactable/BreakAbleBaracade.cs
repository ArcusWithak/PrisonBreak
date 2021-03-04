using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAbleBaracade : MonoBehaviour, Iinteractable
{
    public void action(PlayerControllerScript player)
    {
        player.GiveFeedBack("This stone is cracked, it should break if you hit it hard enough");
    }

    public void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;
         
        if (collisionForce > 900)
        {
            Destroy(this.gameObject);
        }
    }
}

