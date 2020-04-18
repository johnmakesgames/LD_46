using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : PhysicsObject
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        this.tag = "PhysicsObject";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //protected void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Player")
    //    {
    //        DoPickupAction(other.gameObject.GetComponent<MoonManController>());
    //    }
    //}

    protected virtual void DoPickupAction(MoonManController player)
    {
        
    }
}
