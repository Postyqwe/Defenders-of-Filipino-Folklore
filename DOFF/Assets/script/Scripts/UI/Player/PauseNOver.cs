using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseNOver : MonoBehaviour
{
    [Header("Pause UI")]
    public GameObject pauseUI;
    public Button pauseBtn;
    public Button resumeBtn;
    public Button quitBtn;

    [Header("Gameover UI")]
    public GameObject gameoverUI;
    public Button retryBtn;
    public Button mapBtn;

    public DemoLoadScene scene;

    GameObject player;
    Health health;

    void Start()
    {
        // Initially, hide both the pause and game over UI elements
        pauseUI.SetActive(false);
        gameoverUI.SetActive(false);

        // Set up button click listeners
        pauseBtn.onClick.AddListener(PauseGame);
        resumeBtn.onClick.AddListener(ResumeGame);
        quitBtn.onClick.AddListener(MainMenu);
        retryBtn.onClick.AddListener(Retry);
        mapBtn.onClick.AddListener(Map);
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            health = player.GetComponent<Health>();
        }

        if(health.currentHealth <= 0)
        {
            GameOver();
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void GameOver()
    {
        gameoverUI.SetActive(true);
    }

    void Map()
    {
        Time.timeScale = 1f;
        gameoverUI.SetActive(false);
        pauseUI.SetActive(false);
        scene.LoadScene("Map");
    }

    void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scene.LoadScene(currentScene.name);
    }

    void MainMenu()
    {
        Time.timeScale = 1f;
        gameoverUI.SetActive(false);
        pauseUI.SetActive(false);
        scene.LoadScene("MainMenu");
    }
}
