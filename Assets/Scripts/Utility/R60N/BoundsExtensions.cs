using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace R60N.Utility
{
    public static class BoundsExtensions
    {
        public static float Volume(this Bounds bounds)
        {
            float x = bounds.size.x;
            float y = bounds.size.y;    
            float z = bounds.size.z;

            return x * y * z;
        }

        public static float Area(this Bounds bounds)
        {
            return
                2 * bounds.size.x * bounds.size.y +
                2 * bounds.size.y * bounds.size.z +
                2 * bounds.size.z * bounds.size.x;
        }

        public static float AreaXZ(this Bounds bounds)
        {
            return bounds.size.x * bounds.size.z;
        }

        public static Vector3 GetRandomPoint(this Bounds bounds)
        {
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;

            return new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z));
        }
    }
}
