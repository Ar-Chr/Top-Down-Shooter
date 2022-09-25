using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected Input input;
    [SerializeField] protected Stamina stamina;
    [SerializeField] protected Transform cameraTransform;
    [SerializeField] protected GroundDetector groundDetector;
    [Space]
    [SerializeField] protected new Transform transform;
    [SerializeField] protected new Rigidbody rigidbody;
    [SerializeField] protected new CapsuleCollider collider;
    [Header("Movement Stats")]
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float runSpeedModifier;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float jumpSpeed;

    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;

    protected void Start()
    {
        input.OnJump += TryJump;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = cameraTransform.InverseTransformDirection(input.MoveDirection);
        if (input.Sprinting)
            TrySprint(moveDirection);
        else
            Walk(moveDirection);
    }

    private void TrySprint(Vector3 direction)
    {
        if (stamina.CurrentStamina > 0)
        {
            Sprint(direction, out float distanceMoved);
            if (distanceMoved > 0)
                stamina.SpendStamina(Time.deltaTime);
        }
        else
            Walk(direction);
    }

    private void TryJump()
    {
        if (groundDetector.Grounded)
            Jump();
    }

    protected abstract void Walk(Vector3 direction);
    protected abstract void Sprint(Vector3 direction, out float distanceMoved);
    public abstract void Jump();
}