using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraFollowScript : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosLastFrame;

    float distanceToPlayer;

    public Material shaderMat;

    private void Start()
    {
        player = GameObject.Find("Player");
        distanceToPlayer = (player.transform.position - this.transform.position).magnitude;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //this.tag = "PhysicsObject";
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistanceToPlayer = (player.transform.position - this.transform.position).magnitude;

        if (currentDistanceToPlayer > distanceToPlayer + 10)
        {
            this.GetComponent<Rigidbody>().AddForce((player.transform.position - this.transform.position).normalized);
        }

        if (currentDistanceToPlayer < distanceToPlayer - 10)
        {
            this.GetComponent<Rigidbody>().AddForce(-(player.transform.position - this.transform.position).normalized);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, shaderMat);
    }
}
