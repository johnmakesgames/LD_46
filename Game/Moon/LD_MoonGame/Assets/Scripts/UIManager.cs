using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text fuelText;
    public Text energyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        fuelText.text = "Fuel: " + player.GetComponent<MoonManController>().Fuel.ToString();
        energyText.text = "Energy " + player.GetComponent<MoonManController>().Energy.ToString();
    }
}
