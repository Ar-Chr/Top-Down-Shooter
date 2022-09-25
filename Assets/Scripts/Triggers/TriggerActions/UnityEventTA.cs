using UnityEngine;
using UnityEngine.Events;

    public class UnityEventTA : TriggerAction
    {
        [SerializeField] UnityEvent OnTrigger;

        public override void Execute()
        {
            OnTrigger.Invoke();
        }
    }

