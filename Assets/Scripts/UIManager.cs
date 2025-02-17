using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI time;
    public GameObject startButton;

    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score : {_gm.ScoreManager.Score}";
        time.text = $"{TimeSpan.FromSeconds(_gm.TimeManager.Remaining):mm\\:ss}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }
    public void StopGame()
    {
        startButton.SetActive(true);
    }
}
