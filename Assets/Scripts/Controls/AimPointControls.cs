using R60N.Utility;
using UnityEngine;

public class AimPointControls : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private Input input;
    [SerializeField] private new Camera camera;
    [Space]
    [Header("Output")]
    [SerializeField] private Transform aimPoint;
    [Space]
    [Header("Settings")]
    [SerializeField] private float height;
    [SerializeField] private LayerMask layerMask;

    private Vector3 mouseWorldPosition;

    private void Update()
    {
        UpdateMouseWorldPosition(input.Position);
        RaiseAimPointAboveGround();
    }

    private void UpdateMouseWorldPosition(Vector2 position)
    {
        Ray ray = camera.ScreenPointToRay(position);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            return;
        mouseWorldPosition = hit.point;
    }

    private void RaiseAimPointAboveGround()
    {
        Ray ray = new Ray(mouseWorldPosition + Vector3.up, Vector3.down);
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask);
        aimPoint.position = hit.point + Vector3.up * height;
    }
}
