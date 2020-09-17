using ColourCore.Enumerations;
using ColourCore.Objects;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore
{
    namespace Serializables
    {
        [System.Serializable]
        public class Sound
        {
            public string soundName;
            public AudioClip clip;
        }
        [System.Serializable]
        public class CorruptMovement
        {
            public GameObject objectToMove;
            public Vector2 velocity;
            public float delay;
        }
        [System.Serializable]
        public class TimedCorruptMovement
        {
            public GameObject objectToMove;
            public Vector2 velocity;
            public float delay;
            public float duration;
            public bool isMoving = false;
        }
        [System.Serializable]
        public class CorruptExplosion
        {
            public float delay;
            public int rate = 5;
            public float speed = 5f;
            public GameObject prefab;
            public GameObject sender;
        }
    }
}