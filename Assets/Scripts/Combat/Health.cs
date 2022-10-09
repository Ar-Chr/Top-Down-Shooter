using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;
    public event Action Healed;
    public event Action TookDamage;
    public event Action Died;

    [SerializeField] float maxHealth;
    [SerializeField] bool takesDamage;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }
    public bool Alive { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
        Alive = true;
    }

    public void TakeDamage(float damage)
    {
        if (!Alive || !takesDamage)
            return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        TookDamage?.Invoke();
        HealthChanged?.Invoke();

        if (CurrentHealth <= 0)
            Die();
    }

    public void Heal(float value)
    {
        if (!Alive)
            return;

        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + value);
        Healed?.Invoke();
        HealthChanged?.Invoke();
    }

    void Die()
    {
        Alive = false;
        Died?.Invoke();
    }
}

