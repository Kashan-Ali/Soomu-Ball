using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Types of Enemys")]
    //  public GameObject enemyPrefab;
    [SerializeField] private GameObject _lightEnemyPrefab;
    [SerializeField] private GameObject _mediumEnemyPrefab;
    [SerializeField] private GameObject _heavyEnemyPrefab;

    [SerializeField] private GameObject _powerupPrefab;
    private int _enemyCount;
    // Current Player States
    [HideInInspector] public int score = 0;
    [HideInInspector] public int wave = 1;

    // Start is called before the first frame update
    private void OnEnable()
    {
        EnemySpawnWave(wave);
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
        Instantiate(_powerupPrefab, RandomPosition(), _powerupPrefab.transform.rotation);
    }

    private void EnemySpawnWave(int enemiesToSpawn)
    {
        for(int count = 0; count < enemiesToSpawn; count++)
        {
            Instantiate(_lightEnemyPrefab, RandomPosition(), _lightEnemyPrefab.transform.rotation);
            //  Instantiate(_mediumEnemyPrefab, RandomPosition(), _mediumEnemyPrefab.transform.rotation);
            //  Instantiate(_heavyEnemyPrefab, RandomPosition(), _heavyEnemyPrefab.transform.rotation);
        }
    }

    private void WaveCount()
    {
        // Find Enemy Object(Script) from assets.
        _enemyCount = FindObjectsOfType<Enemy>().Length;
        if (_enemyCount == 0)
        {
            wave++;
            EnemySpawnWave(wave);
            PowerupSpawn();
        }
    }
}
