using ColorCore.Enumerations;
using ColorCore.Objects;
using System.Collections.Generic;
using UnityEngine;
namespace ColorCore
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
        public class CorruptExplosion
        {
            public float delay;
            public float rate;
            public float particleSpeed = 5f;
            public GameObject prefab;
            public GameObject sender;
        }
    }
}