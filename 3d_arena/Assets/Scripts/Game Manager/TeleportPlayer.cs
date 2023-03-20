using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Spawner[] ReSpawners;
    public GameObject Player;

    private float _farthestDistance;
    private Transform _farthestTeleport;

    private void Update()
    {
        if (Player.transform.position.y <= -0.5)
        {
            TeleportPlayerToSpawner();
        }
    }

    private void TeleportPlayerToSpawner()
    {
        FindFarthestFromEnemyReSpawner();

        Player.GetComponent<PlayerMovement>().LastPosition = Player.transform.position;
        Player.transform.position = _farthestTeleport.position;
        Player.GetComponent<PlayerMovement>().IsTeleported = true;
    }

    private void FindFarthestFromEnemyReSpawner()
    {
        _farthestDistance = ReSpawners[0].FindNearestEnemy();
        _farthestTeleport = ReSpawners[0].transform;

        for (int i = 1; i < ReSpawners.Length; i++)
        {
            if (_farthestDistance < ReSpawners[i].FindNearestEnemy())
            {
                _farthestDistance = ReSpawners[i].FindNearestEnemy();
                _farthestTeleport = ReSpawners[i].transform;
            }
        }
    }
}
