using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate : MonoBehaviour
{
    public float rotateSpeed;
    public Vector3 rotateAxis;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate((rotateAxis * (rotateSpeed * Time.deltaTime)));
    }
}
