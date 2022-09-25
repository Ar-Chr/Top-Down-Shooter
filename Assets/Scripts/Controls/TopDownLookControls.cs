using System;
using R60N.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownLookControls : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private Transform aimPoint;
    [SerializeField] private Transform characterTransform;

    private void Update()
    {
        UpdateLook();
    }

    private void UpdateLook()
    {
        Vector3 toAimPoint = (aimPoint.position - characterTransform.position).WithY(0);
        float yRotation = Vector3.SignedAngle(toAimPoint, Vector3.forward, Vector3.up);

        characterTransform.rotation = Quaternion.Euler(0, -yRotation, 0);
    }
}