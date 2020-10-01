using ColourCore.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore.Objects
{
    public class DoorTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] float lerpSpeed = 5f;
        [SerializeField] bool _isTriggered;
        public bool isTriggered { get { return _isTriggered;  } set { isTriggered = value; } }
        public string levelName;
        public void Trigger()
        {
            isTriggered = true;
        }
        private void Update()
        {
            if (isTriggered)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(transform.localScale.x, 0f), lerpSpeed * Time.fixedDeltaTime);
            }
        }
    }
}