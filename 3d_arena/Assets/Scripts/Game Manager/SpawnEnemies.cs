using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject FlyingEnemy;
    public GameObject LongRangeEnemy;

    [Header("Rules of Spawn Enemy")]
    public bool LimitNumberEnemies;
    private int _maxNumberOfLongRangeEnemy = 4;
    private int _numberLongRange = 1;
    private int _numberFlying;

    [Header("First Time to Spawn Enemies")]
    public float TimeToSpawn = 5f;
    private bool _isSpawned = false;

    [Header("Position Of Spawners")]
    public float yPosition;
    public Transform[] Spawners;

    private void Update()
    {
        _numberFlying = _numberLongRange * 4;

        if (_isSpawned == false)
        {
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        SpawnEnemiesOnSpawners();
        _isSpawned = true;
        yield return new WaitForSeconds(TimeToSpawn);
        _isSpawned = false;
    }

    private void SpawnEnemiesOnSpawners()
    {
        for (int i = 0; i < _numberLongRange; i++)
        {
            Transform randSpawner = Spawners[Random.Range(0, Spawners.Length)];
            Vector3 randPosition = new Vector3(Random.Range(randSpawner.position.x - 0.8f, randSpawner.position.x + 0.8f),
                                               yPosition,
                                               Random.Range(randSpawner.position.z - 1f, randSpawner.position.z + 1f));

            Instantiate(LongRangeEnemy, randPosition, Quaternion.identity);
        }

        for (int i = 0; i < _numberFlying; i++)
        {
            Transform randSpawner = Spawners[Random.Range(0, Spawners.Length)];
            Vector3 randPosition = new Vector3(Random.Range(randSpawner.position.x - 0.8f, randSpawner.position.x + 0.8f),
                                               yPosition,
                                               Random.Range(randSpawner.position.z - 1f, randSpawner.position.z + 1f));

            Instantiate(FlyingEnemy, randPosition, Quaternion.identity);
        }

        if(LimitNumberEnemies && _numberLongRange == _maxNumberOfLongRangeEnemy)
        {
            return;
        }

        if (TimeToSpawn > 2)
        {
            TimeToSpawn--;
        }

        if(TimeToSpawn == 2)
        {
            _numberLongRange++;
        }
    }
}
