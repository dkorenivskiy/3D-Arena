using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public HealthScript HealthBar;
    public UltBar UltBar;

    public float MaxHealth = 100;
    private float _currentHealth;

    public float MaxUltPoints = 100f;
    [HideInInspector] public float CurrentUltPoints;

    public UnityEvent OnPlayerDied;

    private void Start()
    {
        _currentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        
        CurrentUltPoints = 50f;
        UltBar.SetMaxUlt(MaxUltPoints);
    }

    private void Update()
    {
        UltBar.SetUlt(CurrentUltPoints);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        this.enabled = false;
        OnPlayerDied.Invoke();
    }

    public void GainUltPoints(float UltPoints)
    {
        CurrentUltPoints += UltPoints;
        UltBar.SetUlt(CurrentUltPoints);

        if(CurrentUltPoints == MaxUltPoints)
        {
            Debug.Log("Ult is ready");
        }
    }

    public void TakeUltPointsDamage(float Damage)
    {
        CurrentUltPoints -= Damage;
        UltBar.SetUlt(CurrentUltPoints);
        
        if (CurrentUltPoints < 0)
        {
            CurrentUltPoints = 0;
        }
    }
}
