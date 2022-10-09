using R60N.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coggers
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Input input;
        [SerializeField] private Gun gun;

        private void Update()
        {
            if (input.Shoot)
                gun.TryShoot();

            if (input.Reload)
                gun.TryReload();
        }
    }
}
