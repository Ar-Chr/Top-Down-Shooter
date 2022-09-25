using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace R60N.Utility
{
    public static class Methods
    {
        public static void DelayAction(this MonoBehaviour bhvr, Action action, float delay)
        {
            bhvr.StartCoroutine(DelayActionCoroutine(action, delay));
        }

        private static IEnumerator DelayActionCoroutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        static Camera camera;
        public static Camera Camera
        {
            get
            {
                if (camera is null)
                    camera = Camera.main;
                return camera;
            }
        }

        public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
            return result;
        }
    }
}
