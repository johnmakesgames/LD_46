using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameOver;
    public float plantWaterLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        plantWaterLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        plantWaterLevel -= Time.deltaTime;
        
        if (GameOver)
        {

        }
    }
}
