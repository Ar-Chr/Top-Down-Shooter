using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnProjectileHit : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [Space]
    [SerializeField] private TriggerActionComposite genericActions;
    [SerializeField] private TriggerActionComposite<GameObject> gameObjectActions;

    private void Start()
    {
        projectile.OnHit += Hit;
    }

    private void Hit(RaycastHit hit)
    {
        genericActions.Execute();
        gameObjectActions.Execute(hit.collider.gameObject);
    }
}