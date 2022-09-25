using UnityEngine;

    public class SpawnTA : TriggerAction
    {
        [SerializeField] GameObject spawnObject;
        [SerializeField] Transform spawnTransform;

        public override void Execute()
        {
            Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
        }
    }

