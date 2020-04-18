using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : ItemPickup
{
    Guid itemGUid;
    // Start is called before the first frame update
    void Start()
    {
        itemGUid = Guid.NewGuid();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        this.tag = "PhysicsObject";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<MoonManController>())
        {
            DoPickupAction(other.gameObject.GetComponentInParent<MoonManController>());
        }
    }

    protected override void DoPickupAction(MoonManController player)
    {
        player.AddCarriedWaterCrate(itemGUid);
        Destroy(this.gameObject);
    }
}
