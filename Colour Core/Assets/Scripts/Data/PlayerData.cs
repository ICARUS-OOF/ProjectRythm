using ColorCore.Handlers;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
namespace ColorCore
{
    namespace Data
    {
        public class PlayerData : MonoBehaviour
        {
            public int Health = 3;
            public GameObject HealthItem1, HealthItem2, HealthItem3;
            public void Damage()
            {
                Health--;
                HealthItem1.SetActive(Health >= 3);
                HealthItem2.SetActive(Health >= 2);
                HealthItem3.SetActive(Health >= 1);
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
