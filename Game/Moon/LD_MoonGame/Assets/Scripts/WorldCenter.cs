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

        transform.GetComponent<Rigidbody>().AddForce(targetDirection * GravityStrength);
    }

    public void FixedUpdate()
    {
        var objects = GameObject.FindGameObjectsWithTag("PhysicsObject");
        foreach (var phyicsObject in objects)
        {
            var transform = phyicsObject.GetComponent<Transform>();
            AttractToPlanet(transform);
            phyicsObject.GetComponent<PhysicsObject>().direcitonToMoon = (transform.position - base.transform.position).normalized;
        }

        var waterCubes = GameObject.FindGameObjectsWithTag("WaterCube");
        foreach (var phyicsObject in waterCubes)
        {
            var transform = phyicsObject.GetComponent<Transform>();
            AttractToPlanet(transform);
            phyicsObject.GetComponent<PhysicsObject>().direcitonToMoon = (transform.position - base.transform.position).normalized;
        }
    }
}