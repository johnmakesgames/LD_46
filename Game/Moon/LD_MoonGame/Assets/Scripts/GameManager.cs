using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameOver;
    public float plantWaterLevel;
    string deathType;
    bool gameEnding;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        plantWaterLevel = 100;
        this.gameObject.tag = "GM";
        gameEnding = false;
    }

    public void EndGame(string death)
    {
        deathType = death;
        GameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnding)
        {
            plantWaterLevel -= 0.5f * Time.deltaTime;

            if (plantWaterLevel <= 0)
            {
                GameOver = true;
                GameObject.Find("Player").GetComponent<MoonManController>().Explode();
            }

            if (GameOver)
            {
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        gameEnding = true;
        yield return new WaitForSeconds(5);

        if (deathType == "Energy")
        {
            SceneManager.LoadScene("GameOver_Death");
        }
        else
        {
            SceneManager.LoadScene("GameOver_Flower");
        }
    }
}
