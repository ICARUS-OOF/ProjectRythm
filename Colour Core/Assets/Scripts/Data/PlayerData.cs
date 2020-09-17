using ColourCore.Handlers;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
namespace ColourCore
{
    namespace Data
    {
        public class PlayerData : MonoBehaviour
        {
            public int Health = 3;
            public void Damage()
            {
                if (Health <= 0)
                {

                }
            }
            private void Update()
            {
            
            }
        }
    }
}
