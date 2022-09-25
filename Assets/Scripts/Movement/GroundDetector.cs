using R60N.Utility;
using UnityEngine;

[ExecuteAlways]
public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform checkOrigin;
    [Space]
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;
    [Space]
    [SerializeField] private float maxSlopeAngle = 45;

    public bool Grounded { get; private set; }

    private void FixedUpdate()
    {
        UpdateGrounded();
    }

    private void UpdateGrounded()
    {
        Ray ray = new Ray(checkOrigin.position, Vector3.down);
        if (!Physics.SphereCast(ray, radius, out RaycastHit hit, distance, layerMask))
        {
            Grounded = false;
            return;
        }

        Grounded = Vector3.Angle(hit.normal, Vector3.up) <= maxSlopeAngle;
    }

    void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        Gizmos.color = Grounded ? transparentGreen : transparentRed;

        Gizmos.DrawSphere(checkOrigin.position, radius);
        Gizmos.DrawSphere(checkOrigin.position.WithYPlus(-distance), radius);
    }
}