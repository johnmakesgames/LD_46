using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCenter : MonoBehaviour
{
    public float GravityStrength = -10;

    private void AttractToPlanet(Transform transform)
    {
        Vector3 targetDirection = (transform.position - base.transform.position).normalized;
        Vector3 otherUpDirection = transform.up;
        transform.rotation = Quaternion.FromToRotation(otherUpDirection, targetDirection) * transform.rotation;

        var directionTo = (transform.position - this.transform.position);
        var distance = (directionTo.magnitude - 100 > 1) ? directionTo.magnitude - 100 : 1;
        Debug.Log(distance);
        transform.GetComponent<Rigidbody>().AddForce(targetDirection * (GravityStrength * distance));
    }

    public void FixedUpdate()
    {
        var objects = GameObject.FindGameObjectsWithTag("PhysicsObject");
        foreach(var phyicsObject in objects)
        {
            var transform = phyicsObject.GetComponent<Transform>();
            AttractToPlanet(transform);
        }
    }
}