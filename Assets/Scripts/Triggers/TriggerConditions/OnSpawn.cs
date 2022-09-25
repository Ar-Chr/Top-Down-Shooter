using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawn : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    [Space]
    [SerializeField] TriggerActionComposite genericActions;
    [SerializeField] TriggerActionComposite<GameObject> gameObjectActions;

    private void Start()
    {
        spawner.Spawned += HandleSpawned;
    }

    private void HandleSpawned(GameObject entity)
    {
        genericActions?.Execute();
        gameObjectActions?.Execute(entity);
    }
}
