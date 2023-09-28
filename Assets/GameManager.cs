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
    public float countTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCountDown.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            gameOverCountDown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
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
