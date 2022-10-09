using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R60N.Utility;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform barTransform;
    [SerializeField] private Health health;

    private void Start()
    {
        health.HealthChanged += UpdateHealth;
    }

    private void UpdateHealth()
    {
        barTransform.localScale = barTransform.localScale.WithX(health.CurrentHealth / health.MaxHealth);
    }
}

