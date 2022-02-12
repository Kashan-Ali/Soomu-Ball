﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int Difficulty = 1;

    // Start is called before the first frame update
    private void Start()
    {
        EnemySpawnWave(Difficulty);
        PowerupSpawn();
    }

    private void Update()
    {
        WaveCount();
    }

    private Vector3 RandomPosition()
    {
        float _random = Random.Range(-9, 9);
        Vector3 _spawnPos = new Vector3(_random, 0.1f, _random);

        return _spawnPos;
    }

    private void PowerupSpawn()
    {
        Instantiate(powerupPrefab, RandomPosition(), powerupPrefab.transform.rotation);
    }

    private void EnemySpawnWave(int enemiesToSpawn)
    {
        for(int count = 0; count < enemiesToSpawn; count++)
        {
            Instantiate(enemyPrefab, RandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void WaveCount()
    {
        // Find Enemy Object(Script) from assets.
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Difficulty++;
            EnemySpawnWave(Difficulty);
            PowerupSpawn();
        }
    }
}