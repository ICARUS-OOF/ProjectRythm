using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore
{
    namespace Movement
    {
        public class CameraFollowMovement : MonoBehaviour
        {
            public Transform PlayerTransform;

            public float movementSpeed = 3f;

            private void Update()
            {
                transform.position = Vector3.Lerp(
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                    new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, transform.position.z), 
                    movementSpeed * Time.deltaTime);
            }
        }
    }
}