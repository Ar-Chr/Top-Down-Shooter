using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public event Action<GameObject> Spawned;

    [Header("Input")]
    [SerializeField] private Transform spawnPoint;
    [Space]
    [Header("Settings")]
    [SerializeField] private GameObject entityPrefab;
    [SerializeField] private float cooldown;

    float currentCooldown;

    private void Update()
    {
        if (currentCooldown <= 0)
        {
            Spawn();
            currentCooldown = cooldown;
        }

        currentCooldown -= Time.deltaTime;
    }

    private void Spawn()
    {
        GameObject entity = Instantiate(entityPrefab, spawnPoint.position, Quaternion.identity);
        Spawned?.Invoke(entity);
    }
}
