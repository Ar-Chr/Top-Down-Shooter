using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCharacterMovement : CharacterMovement
{
    [Space]
    [SerializeField] float rbDrag;

    float moveSpeedMultiplier;

    private void OnValidate()
    {
        rigidbody.drag = rbDrag;
        moveSpeedMultiplier = rbDrag / (1 - rbDrag * Time.fixedDeltaTime);
    }

    private new void Start()
    {
        base.Start();
        rigidbody.isKinematic = false;
    }

    public override void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
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
        Vector3 normalizedDirection = new Vector3(direction.x, 0, direction.y).normalized;
        Vector3 desiredMovement = normalizedDirection * speed;

        Vector3 prevPosition = rigidbody.position;
        rigidbody.MovePosition(prevPosition + desiredMovement * Time.deltaTime);

        //rigidbody.AddForce(desiredMovement * moveSpeedMultiplier, ForceMode.Acceleration);

        distanceMoved = (rigidbody.position - prevPosition).magnitude;
    }
}