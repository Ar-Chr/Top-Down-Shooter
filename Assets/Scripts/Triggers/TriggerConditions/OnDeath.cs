using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coggers
{
    public class OnDeath : MonoBehaviour
    {
        [SerializeField] private Health health;
        [Space]
        [SerializeField] private TriggerActionComposite genericActions;
        [SerializeField] private TriggerActionComposite<GameObject> gameObjectActions;
        [SerializeField] private TriggerActionComposite<Health> healthActions;

        private void Start()
        {
            health.Died += Died;
        }

        private void Died()
        {
            genericActions.Execute();
            gameObjectActions.Execute(health.gameObject);
            healthActions.Execute(health);
        }
    }
}
