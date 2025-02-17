using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    public float spawnDelay = 2f;
    public readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;

    public event Action<Rupee> OnCollected;

    public void StartGame()
    {
        StartSpawning();
    }

    public void StopGame()
    {
        StopSpawning();

        for (var i = _rupees.Count -1; i >= 0; i--)
        {
            RemoveRupee(_rupees[i]);
        }
    }

    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void StopSpawning()
    {
        if (_spawnRoutine == null) return;
        StopCoroutine(_spawnRoutine);
        _spawnRoutine = null;
    }

    private void Spawn()
    {
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
        rupee.transform.parent = container;
        AddRupee(rupee);
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
        StartSpawning();
    }

    private void AddRupee(Rupee rupee)
    {
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
        Destroy(rupee.gameObject);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}
