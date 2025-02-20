using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;


    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private int currentScore = 0;
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        instance = this;
        uiManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void StartGame()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

}