using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore
{
    namespace Handlers
    {
        public class SpriteHandler : MonoBehaviour
        {
            private void Update()
            {
                SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

                foreach (SpriteRenderer renderer in renderers)
                {
                    renderer.sortingOrder = (int)(renderer.transform.position.y * -100f);
                }
            }
        }
    }
}
