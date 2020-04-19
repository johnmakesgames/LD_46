using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider fuelBar;
    public Slider energyBar;
    public Slider waterBar;
    public Text warningText;

    public GameObject arrow;
    public GameObject energyArrow;
    public GameObject waterArrow;

    float flashTime;

    // Start is called before the first frame update
    void Start()
    {
        warningText.text = "";
        flashTime = 0;
        var thread = new Thread(() => AdjustWaterArrow());
        thread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustPlantArrow();
        AdjustEnergyArrow();
        AdjustWaterArrow();

        GameObject player = GameObject.Find("Player");
        fuelBar.value =  player.GetComponent<MoonManController>().Fuel / 100;
        energyBar.value = player.GetComponent<MoonManController>().Energy / 100;

        GameManager gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        waterBar.value = gm.plantWaterLevel/100;


        if (player.GetComponent<MoonManController>().Energy < 25 || gm.plantWaterLevel < 25)
        {
            if (warningText.text == "" && flashTime > 0.3f)
            {
                warningText.text = "WARNING";
                flashTime = 0;
            }
            else if (flashTime > 0.3f)
            {
                warningText.text = "";
                flashTime = 0;
            }

            flashTime += Time.deltaTime;
        }
        else
        {
            warningText.text = "";
        }

    }

    void AdjustPlantArrow()
    {
        Vector3 playerForward = GameObject.Find("Player").transform.forward;
        Vector3 between = GameObject.Find("Flower").transform.position - GameObject.Find("Player").transform.position;

        //playerForward.y = 0;
        //between.y = 0;

        Vector3 cross = Vector3.Cross(between, playerForward);
        Debug.Log(cross);

        if (cross.y < 0)
            arrow.transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(playerForward, between));
        else
            arrow.transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(playerForward, between));
    }

    void AdjustEnergyArrow()
    {
        var allEnergyPads = GameObject.FindGameObjectsWithTag("EnergyPad");

        Vector3 playerPos = GameObject.Find("Player").transform.position;
        GameObject closestPad = null;
        float closestDistance = float.MaxValue;
        foreach(var pad in allEnergyPads)
        {
            if (Vector3.Distance(playerPos, pad.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(playerPos, pad.transform.position);
                closestPad = pad;
            }
        }

        Vector3 playerForward = GameObject.Find("Player").transform.forward;
        Vector3 between = closestPad.transform.position - GameObject.Find("Player").transform.position;

        playerForward.y = 0;
        between.y = 0;

        Vector3 cross = Vector3.Cross(between, playerForward);
        Debug.Log(cross);

        if (cross.y < 0)
            energyArrow.transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(playerForward, between));
        else
            energyArrow.transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(playerForward, between));
    }

    void AdjustWaterArrow()
    {
        var allWaterCubes = GameObject.FindGameObjectsWithTag("WaterCube");

        Vector3 playerPos = GameObject.Find("Player").transform.position;
        GameObject closestPad = null;
        float closestDistance = float.MaxValue;
        foreach (var pad in allWaterCubes)
        {
            if (Vector3.Distance(playerPos, pad.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(playerPos, pad.transform.position);
                closestPad = pad;
            }
        }

        Vector3 playerForward = GameObject.Find("Player").transform.forward;
        Vector3 between = closestPad.transform.position - GameObject.Find("Player").transform.position;

        playerForward.y = 0;
        between.y = 0;

        Vector3 cross = Vector3.Cross(between, playerForward);
        Debug.Log(cross);

        if (cross.y < 0)
            waterArrow.transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(playerForward, between));
        else
            waterArrow.transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(playerForward, between));
    }
}
