using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public Action Changed;

    [SerializeField] private float maxStamina;
    [SerializeField] private float currentStamina;
    [SerializeField] private float costPerSecond;
    [SerializeField] private float regenPerSecond;
    [SerializeField] private float regenDelay;

    private float currentRegenDelay;

    public float MaxStamina => maxStamina;
    public float CurrentStamina => currentStamina;

    private void FixedUpdate()
    {
        if (currentRegenDelay <= 0 && currentStamina < maxStamina)
            RegenStamina(Time.fixedDeltaTime);

        currentRegenDelay -= Time.fixedDeltaTime;
    }

    public void RegenStamina(float time)
    {
        float newStamina = Mathf.Min(currentStamina + regenPerSecond * time, maxStamina);
        SetStamina(newStamina);
    }

    public void SpendStamina(float time)
    {
        if (time == 0)
            return;

        float newStamina = Mathf.Max(currentStamina - costPerSecond * time, 0);
        currentRegenDelay = regenDelay;
        SetStamina(newStamina);
    }

    private void SetStamina(float newStamina)
    {
        currentStamina = newStamina;
        Changed?.Invoke();
    }
}
