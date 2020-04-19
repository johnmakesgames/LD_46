using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonManController : MonoBehaviour
{
    private float movementSpeed = 700;
    private float jumpForce = 800;

    GameObject frontWheelLeft;
    GameObject frontWheelRight;
    GameObject backWheelLeft;
    GameObject backWheelRight;

    GameObject jetpackLeft;
    GameObject jetpackRight;

    GameObject roboBottom;
    GameObject roboMiddle;
    GameObject roboHead;
    GameObject roboAxle;

    GameObject carryingArea;

    public float Fuel;
    public float fuelDrainSpeed;

    public float Energy;
    public float energyDrainSpeed;

    public GameObject WaterCrateInstance;
    private int countofBlocks;

    List<GameObject> spawnedWaterBlocks = new List<GameObject>();
    List<Guid> guidsUsed = new List<Guid>();

    private void Start()
    {
        frontWheelLeft = GameObject.Find("Wheel_Front_Left");
        frontWheelRight = GameObject.Find("Wheel_Front_Right");
        backWheelLeft = GameObject.Find("Wheel_Back_Left");
        backWheelRight = GameObject.Find("Wheel_Back_Right");
        jetpackLeft = GameObject.Find("JetPack_Left");
        jetpackRight = GameObject.Find("JetPack_Right");
        roboBottom = GameObject.Find("Robo_Bottom");
        roboMiddle = GameObject.Find("Robo_Middle");
        roboHead = GameObject.Find("Robo_Head");
        roboAxle = GameObject.Find("Robo_Axle");
        carryingArea = GameObject.Find("CarryingArea");

        Fuel = 100;
        fuelDrainSpeed = 50;

        Energy = 100;
        energyDrainSpeed = 0.5f;

        countofBlocks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var rb    = this.GetComponent<Rigidbody>();
        var physicsObject = this.GetComponent<PhysicsObject>();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(this.transform.forward * movementSpeed * Time.deltaTime);

            frontWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, -1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, -1.0f, 0));

            Energy -= 1 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(this.transform.forward * -movementSpeed * Time.deltaTime);

            frontWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            frontWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelLeft.transform.Rotate(new Vector3(0, 1.0f, 0));
            backWheelRight.transform.Rotate(new Vector3(0, 1.0f, 0));

            Energy -= 1 * Time.deltaTime;
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
        else if (Input.GetKey(KeyCode.D))
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
            jetpackLeft.transform.Rotate(new Vector3(50, 0, 0));
            jetpackRight.transform.Rotate(new Vector3(50, 0, 0));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jetpackLeft.transform.Rotate(new Vector3(-50, 0, 0));
            jetpackRight.transform.Rotate(new Vector3(-50, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            jetpackLeft.transform.Rotate(new Vector3(-50, 0, 0));
            jetpackRight.transform.Rotate(new Vector3(-50, 0, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            jetpackLeft.transform.Rotate(new Vector3(50, 0, 0));
            jetpackRight.transform.Rotate(new Vector3(50, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftControl) && Fuel > 0)
        {
            rb.AddForce(physicsObject.direcitonToMoon * -jumpForce * Time.deltaTime);
            Fuel -= fuelDrainSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space) && Fuel > 0)
        {
            rb.AddForce(physicsObject.direcitonToMoon * (jumpForce * 2) * Time.deltaTime);
            Fuel -= fuelDrainSpeed * Time.deltaTime;
        }
        else
        {
            Fuel += fuelDrainSpeed / 10 * Time.deltaTime;
        }

        if (Fuel > 100)
        {
            Fuel = 100;
        }
        if (Fuel < 0)
        {
            Fuel = 0;
        }

        Energy -= (energyDrainSpeed + (countofBlocks/2)) * Time.deltaTime;

        CheckDeath();
    }

    public void CheckDeath()
    {
        if (Energy <= 0)
        {
            Explode();
            GameObject.Find("GM").GetComponent<GameManager>().EndGame("Energy");
        }
    }

    public void Explode()
    {
        frontWheelLeft.AddComponent<Rigidbody>();
        frontWheelRight.AddComponent<Rigidbody>();
        backWheelLeft.AddComponent<Rigidbody>();
        backWheelRight.AddComponent<Rigidbody>();
        jetpackLeft.AddComponent<Rigidbody>();
        jetpackRight.AddComponent<Rigidbody>();
        roboBottom.AddComponent<Rigidbody>();
        roboMiddle.AddComponent<Rigidbody>();
        roboHead.AddComponent<Rigidbody>();
        roboAxle.AddComponent<Rigidbody>();

        foreach (GameObject blocks in spawnedWaterBlocks)
        {
            blocks.AddComponent<Rigidbody>();
        }
    }

    public void AddCarriedWaterCrate(Guid guid)
    {
        if (!guidsUsed.Contains(guid))
        {
            var cube = GameObject.Instantiate(WaterCrateInstance, carryingArea.transform);
            cube.transform.position = carryingArea.transform.position + (this.transform.up * countofBlocks);
            spawnedWaterBlocks.Add(cube);
            countofBlocks++;
            guidsUsed.Add(guid);
        }
    }

    public int DeliverWater()
    {
        int countToReturn = countofBlocks;
        countofBlocks = 0;
        guidsUsed.Clear();
        foreach(var cube in spawnedWaterBlocks)
        {
            Destroy(cube.gameObject);
        }
        spawnedWaterBlocks.Clear();

        return countToReturn;
    }
}