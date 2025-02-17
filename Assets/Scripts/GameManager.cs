using System;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // singleton en unity
    public static GameManager Instance { get; private set; }
    public RupeeManager RupeeManager { get; private set; } 
    public ScoreManager ScoreManager { get; private set; }
    public UIManager UIManager { get; private set; }
    public TimeManager TimeManager { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        UIManager = GetComponent<UIManager>();
        TimeManager = GetComponent<TimeManager>();
    }
    public void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
    }

    private void TimeUpHandler()
    {
        StopGame();
    }

    public void StartGame()
    {
        TimeManager.OnTimeUp += TimeUpHandler;

        ScoreManager.StartGame();
        UIManager.StartGame();
        TimeManager.StartGame();
        RupeeManager.StartGame();
    }

    public void StopGame()
    {
        TimeManager.OnTimeUp -= TimeUpHandler;

        UIManager.StopGame();
        RupeeManager.StopGame();
        TimeManager.StopGame();
    }
}
