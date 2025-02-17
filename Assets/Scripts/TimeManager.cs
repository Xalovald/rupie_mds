using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float duration = 120f;
    public float Remaining {  get; private set; }
    public bool Running {  get; private set; }

    public event Action OnTimeUp;

    public void Update()
    {
        if (Running)
        {
            Tick(Time.deltaTime);
        }
    }

    public void Tick(float DeltaTime)
    {
        Remaining -= Time.deltaTime;

        if(Remaining <= 0f) 
        { 
            Remaining = 0f;
            OnTimeUp?.Invoke();
        }
    }

    public void StartGame()
    {
        Remaining = duration;
        Running = true;
    }
    public void StopGame()
    {
        Running = false;
    }
}
