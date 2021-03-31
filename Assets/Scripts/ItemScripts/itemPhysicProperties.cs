using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPhysicProperties : MonoBehaviour
{
    private Rigidbody rB;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (transform.position.y < 15 && transform.position.y > 0)
        {
            rB.AddForceAtPosition((-Physics.gravity / (transform.position.y / 5f)), transform.position + -transform.up, ForceMode.Force);
        }
    }
}
