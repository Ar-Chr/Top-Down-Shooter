using UnityEngine;

public class HealTA : TriggerAction<Health>
{
    [SerializeField] int healthAmount = 10;

    public override void Execute(Health health)
    {
        health.Heal(healthAmount);
    }
}
