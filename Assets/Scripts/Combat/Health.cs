using System;
using UnityEngine;

public class Health : MonoBehaviour
{
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

        CurrentHealth -= damage;
        TookDamage?.Invoke();

        if (CurrentHealth <= 0)
            Die();
    }

    void Die()
    {
        Alive = false;
        Died?.Invoke();
    }
}

