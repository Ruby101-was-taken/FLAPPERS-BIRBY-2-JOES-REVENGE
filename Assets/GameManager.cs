using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public PLayer player;
    public TMP_Text gameOverCountDown;
    public Spawner spawner;
    public float countTimer = 5;
    public int gameMode = 0;

    private float gameSwitchTimer = 0f;
    private int gameSwitchAt = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCountDown.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameSwitchTimer);
        if (gameSwitchTimer % 1 == 0)
        {
            Debug.Log(gameSwitchTimer);
        }
        if (player.isDead)
        {
            gameOverCountDown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
        }
        else
        {
            gameSwitchTimer += Time.unscaledDeltaTime;
            if(gameSwitchTimer >= gameSwitchAt)
            {
                spawner.reverseTime();
                gameSwitchTimer = 0f;
                gameSwitchAt = Random.Range(5, 5);
                Debug.Log(gameSwitchAt);
                if (gameMode == 0)
                {
                    gameMode = 1;
                }
                else
                {
                    gameMode = 0;
                }
            }
        }
        gameOverCountDown.text = "Restarting in " + (countTimer).ToString("0");
        if(countTimer < 0)
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
}
