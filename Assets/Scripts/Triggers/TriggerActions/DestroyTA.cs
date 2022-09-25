using UnityEngine;

    public class DestroyTA : TriggerAction
    {
        [SerializeField] private GameObject target;

        public override void Execute()
        {
            Destroy(target);
        }
    }

