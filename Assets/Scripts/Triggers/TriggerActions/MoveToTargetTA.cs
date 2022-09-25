using UnityEngine;

    public class MoveToTargetTA : TriggerAction<GameObject>
    {
        new Transform transform;

        private void Start()
        {
            transform = base.transform;
        }

        public override void Execute(GameObject target)
        {
            transform.position = target.transform.position;
        }
    }
