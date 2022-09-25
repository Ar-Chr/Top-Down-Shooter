using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coggers
{
    public class MeleeDamageDealer : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float cooldown;

        private float currentCooldown;

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out Health health))
                return;

            TryAttack(health);
        }

        private void TryAttack(Health health)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                Attack(health);
                currentCooldown = cooldown;
            }
        }

        private void Attack(Health health)
        {
            health.TakeDamage(damage);
        }
    }
}
