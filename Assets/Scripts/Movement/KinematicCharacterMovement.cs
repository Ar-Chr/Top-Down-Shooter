using R60N.Utility;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCharacterMovement : CharacterMovement
{
    int iterations = 3;

    [Space]
    [SerializeField] private bool usesGravity;
    [SerializeField] private float maxSlopeAngle = 40;

    Vector3 sphereCenterOffset => Vector3.up * (collider.height / 2 - collider.radius);

    bool grounded;
    //{
    //    get
    //    {
    //        return groundDetector.Grounded && velocity.y <= 0;
    //    }
    //}

    Vector3 velocity;
    Vector3 totalMovement;
    List<Vector3> movements = new List<Vector3>();

    void OnValidate()
    {
        runSpeed = walkSpeed * runSpeedModifier;
    }

    void Reset()
    {
        TryGetMissingComponents();
    }

    void TryGetMissingComponents()
    {
        if (transform is null) transform = GetComponent<Transform>();
        if (rigidbody is null) rigidbody = GetComponent<Rigidbody>();
        if (collider is null) collider = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        rigidbody.isKinematic = true;
    }

    void FixedUpdate()
    {
        grounded = groundDetector.Grounded;

        if (grounded)
            velocity.y = 0;

        if (!grounded && usesGravity)
            AddVelocity(Physics.gravity * Time.deltaTime);

        MakeMovement();
    }

    protected override void Walk(Vector3 direction)
    {
        Move(direction, walkSpeed, out float distanceMoved);
    }

    protected override void Sprint(Vector3 direction, out float distanceMoved)
    {
        Move(direction, runSpeed, out distanceMoved);
    }

    private void Move(Vector3 direction, float speed, out float distanceMoved)
    {
        if (!grounded)
        {
            distanceMoved = 0;
            return;
        }

        Vector3 desiredMovement = direction.normalized;
        desiredMovement *= speed;

        distanceMoved = desiredMovement.magnitude;
        AddMovement(desiredMovement);
    }

    public override void Jump()
    {
        if (!grounded)
            return;

        AddVelocity(Vector3.up * jumpSpeed);
    }

    void AddMovement(Vector3 desiredMovement)
    {
        totalMovement += desiredMovement;
    }

    void AddVelocity(Vector3 velocity)
    {
        this.velocity += velocity;
    }

    void MakeMovement()
    {
        AddMovement(velocity * Time.deltaTime);
        GetTotalMovement(movements, totalMovement);
        totalMovement = Vector3.zero;

        for (int i = 0; i < movements.Count; i++)
            rigidbody.MovePosition(transform.position + movements[i]);
    }

    void GetTotalMovement(List<Vector3> movements, Vector3 desiredMovement)
    {
        movements.Clear();
        float remainingDistance = desiredMovement.magnitude;
        RaycastHit? hit;
        Vector3 virtualPosition = transform.position;
        for (int i = 0; i < iterations; i++)
        {
            Vector3 movement = GetMovement(virtualPosition, desiredMovement, out hit);
            movements.Add(movement);

            if (!hit.HasValue)
                break;

            if (Vector3.Angle(hit.Value.normal, Vector3.up) <= maxSlopeAngle)
                grounded = true;

            virtualPosition += movement;
            remainingDistance -= hit.Value.distance;
            Vector3 remDistancePercent = ProjectMovementOnPlane(desiredMovement, hit.Value.normal) / desiredMovement.magnitude;
            desiredMovement = remDistancePercent * remainingDistance;
        }
    }

    Vector3 GetMovement(Vector3 position, Vector3 desiredMovement, out RaycastHit? hit)
    {
        Vector3 movement = desiredMovement;
        hit = null;

        if (Cast(position, desiredMovement, out RaycastHit hitTemp))
        {
            hit = hitTemp;
            float movementPercent = (hit.Value.distance - Constants.Epsilon) / desiredMovement.magnitude;
            movement = desiredMovement * movementPercent;
        }

        return movement;
    }

    bool Cast(Vector3 position, Vector3 desiredMovement, out RaycastHit hit)
    {
        position += collider.center;
        return Physics.CapsuleCast(
            position + sphereCenterOffset,
            position - sphereCenterOffset,
            collider.radius,
            desiredMovement,
            out hit,
            desiredMovement.magnitude);
    }

    Vector3 ProjectMovementOnPlane(Vector3 movement, Vector3 normal)
    {
        return Vector3.Cross(normal, Vector3.Cross(movement, Vector3.up));
    }

#if UNITY_EDITOR
    //List<Vector3> gizmoMovements = new List<Vector3>();

    //void OnDrawGizmosSelected()
    //{
    //    DrawBounces();
    //    groundDetector.DrawGroundedChecker();
    //}

    //void DrawBounces()
    //{
    //    GetTotalMovement(gizmoMovements, transform.forward * 6);

    //    Vector3 virtualPosition = transform.position + collider.center;
    //    for (int i = 0; i < gizmoMovements.Count; i++)
    //    {
    //        virtualPosition += gizmoMovements[i];
    //        Color color = Color.Lerp(Color.blue, Color.white, (float)i / iterations);
    //        GizmosExtensions.DrawWireCapsule(virtualPosition, color);
    //    }
    //}
#endif
}

