using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace ColourCore.Editor
{
    public class OnlySpriteEditor : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            GetComponent<SpriteShapeController>().enabled = true;
        }
        private void Start()
        {
            GetComponent<SpriteShapeController>().enabled = false;
        }
    }
}