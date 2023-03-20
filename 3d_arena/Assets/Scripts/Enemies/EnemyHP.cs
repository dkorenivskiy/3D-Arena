using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHP : MonoBehaviour
{
    public float MaxHealth = 50f;
    private float _currentHealth;

    public float UltPointsForKilling;
    private GameObject _player;

    public UnityEvent GainingScore;

    private void Start()
    {
        _currentHealth = MaxHealth;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _player.GetComponent<PlayerStats>().GainUltPoints(UltPointsForKilling);
        GainingScore.Invoke();
        Destroy(gameObject);
    }
}
