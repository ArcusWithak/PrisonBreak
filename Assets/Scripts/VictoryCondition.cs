using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : itemPhysicProperties
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("you win");
        }
    }
}
