using R60N.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineControls : MonoBehaviour
{
    [SerializeField] private new Transform characterTransform;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform aimPoint;
    [Space]
    [SerializeField] private Transform line;
    [Space]
    [SerializeField] private float maxDistance;
    [SerializeField] private float extraDistance;

    private void Update()
    {
        Vector3 direction = (aimPoint.position - characterTransform.position).WithY(0);
        Ray ray = new Ray(muzzle.position, direction);

        float distance = maxDistance;
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            distance = hit.distance + extraDistance;

        line.localScale = Vector3.one.WithZ(distance);
    }
}
