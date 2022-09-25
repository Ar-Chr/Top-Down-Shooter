using UnityEngine;

namespace R60N.Utility
{
    public static class GizmosExtensions
    {
        static Mesh capsuleMesh;
        static Mesh CapsuleMesh
        {
            get
            {
                if (capsuleMesh == null)
                {
                    GameObject capsule= GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    capsuleMesh = capsule.GetComponent<MeshFilter>().sharedMesh;
                    Object.DestroyImmediate(capsule);
                }
                return capsuleMesh;
            }
        }

        public static void DrawWireCapsule(Vector3 position)
        {
            Gizmos.DrawWireMesh(CapsuleMesh, position);
        }

        public static void DrawWireCapsule(Vector3 position, Color color)
        {
            Color prevColor = Gizmos.color;
            Gizmos.color = color;
            Gizmos.DrawWireMesh(CapsuleMesh, position);
            Gizmos.color = prevColor;
        }
    }
}
