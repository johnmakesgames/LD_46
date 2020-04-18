using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonManController : MonoBehaviour
{
    private float movementSpeed = 700;
    private float jumpForce = 80000;

    GameObject frontWheelLeft;
    GameObject frontWheelRight;
    GameObject backWheelLeft;
    GameObject backWheelRight;

    private void Start()
    {
        frontWheelLeft = GameObject.Find("Wheel_Front_Left");
        frontWheelRight = GameObject.Find("Wheel_Front_Right");
        backWheelLeft = GameObject.Find("Wheel_Back_Left");
        backWheelRight = GameObject.Find("Wheel_Back_Right");
    }

    // Update is called once per frame
    void Update()
    {
        var rb = this.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(this.transform.forward * movementSpeed * Time.deltaTime);

            frontWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(this.transform.forward * -movementSpeed * Time.deltaTime);

            frontWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Rotate left
            Vector3 currentForward = this.transform.forward;
            var rotatedForward = Quaternion.AngleAxis(-100 * Time.deltaTime, transform.up) * currentForward;

            transform.rotation = Quaternion.FromToRotation(currentForward, rotatedForward) * transform.rotation;

            frontWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Rotate left
            Vector3 currentForward = this.transform.forward;
            var rotatedForward = Quaternion.AngleAxis(100 * Time.deltaTime, transform.up) * currentForward;

            transform.rotation = Quaternion.FromToRotation(currentForward, rotatedForward) * transform.rotation;

            frontWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(this.transform.up * jumpForce * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.AddForce(this.transform.up * -(jumpForce/2) * Time.deltaTime);
        }
    }
}