using ColourCore.Enumerations;
using ColourCore.Objects;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore.Serializables
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
        public bool LerpZeroOnFinish = false;
    }
    [System.Serializable]
    public class CorruptExplosion
    {
        public float delay;
        public int rate = 5;
        public float speed = 5f;
        public bool shake = true;
        public GameObject prefab;
        public GameObject sender;
    }
    [System.Serializable]
    public class ObjectRotation
    {
        public GameObject objToRotate;
        public float delay;
        public float RotationValue = 10f;
    }
    [System.Serializable]
    public class ObjectEnabler
    {
        public GameObject objToEnable;
        public float delay;
        public float duration;
    }
}