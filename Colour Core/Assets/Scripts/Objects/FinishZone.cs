using ColourCore.Handlers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore.Objects
{
    public class FinishZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                GameHandler.singleton.onFinishLevel?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}