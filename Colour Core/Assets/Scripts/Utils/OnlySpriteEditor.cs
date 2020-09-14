﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace ColorCore
{
    namespace Editor
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
}