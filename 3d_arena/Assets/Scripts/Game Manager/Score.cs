using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector] public int KilledEnemies = 0;

    public void GainScorePoint()
    {
        KilledEnemies++;
    }
}
