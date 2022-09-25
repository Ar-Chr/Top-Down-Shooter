using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coggers
{
    public class OnProjectileHit : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [Space]
        [SerializeField] private TriggerActionComposite genericActions;
        [SerializeField] private TriggerActionComposite<Health> healthActions;

        private void Start()
        {
            projectile.OnHit += Hit;
        }

        private void Hit(RaycastHit hit)
        {
            if (hit.collider.gameObject.TryGetComponent(out Health health))
            {
                genericActions.Execute();
                healthActions.Execute(health);
            }
        }
    }
}
