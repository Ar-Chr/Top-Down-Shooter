using R60N.Utility;
using System;
using UnityEngine;

public static class CombatUtility
{
    public static bool TryGetAttackAngle(Vector3 muzzle, Vector3 target, float muzzleVelocity, out float angle, bool low = true)
    {
        float speedSq = muzzleVelocity * muzzleVelocity;
        float g = 9.81f;

        Vector3 toTarget = target - muzzle;
        float x = toTarget.WithY(0).magnitude;
        float y = toTarget.y;

        float underSqrt = speedSq * speedSq - g * (g * x * x + 2 * y * speedSq);

        if (underSqrt >= 0)
        {
            angle = Mathf.Rad2Deg * (low ?
                Mathf.Atan2(speedSq - Mathf.Sqrt(underSqrt), g * x) :
                Mathf.Atan2(speedSq + Mathf.Sqrt(underSqrt), g * x));
            return true;
        }

        angle = 0;
        return false;
    }

    public static float GetProjectileLifetime(float muzzleVelocity)
    {
        return 400 / muzzleVelocity;
    }
}