using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[] _allEnemies;

    void Update()
    {
        _allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public float FindNearestEnemy()
    {
        if (_allEnemies.Length == 0)
        {
            return 0f;
        }

        float nearestEnemyDistance = Vector3.Distance(transform.position, _allEnemies[0].transform.position);
        for (int i = 1; i < _allEnemies.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, _allEnemies[i].transform.position);
            if (distance < nearestEnemyDistance)
            {
                nearestEnemyDistance = distance;
            }
        }

        return nearestEnemyDistance;
    }
}
