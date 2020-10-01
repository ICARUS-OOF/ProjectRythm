using System.Collections;
using UnityEngine;
namespace ColourCore.Objects
{
    public class CameraController : MonoBehaviour
    {
        #region Singleton
        public static CameraController singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        float shakeAmount = 0;
        public void Shake(float amnt, float length)
        {
            shakeAmount = amnt;
            InvokeRepeating("BeginShake", 0, 0.01f);
            Invoke("StopShake", length);
        }
        private void BeginShake()
        {
            if (shakeAmount > 0)
            {
                Vector3 originalPos = transform.position;

                float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
                float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
                originalPos.x += offsetX;
                originalPos.y += offsetY;

                transform.position = originalPos;
            }
        }
        private void StopShake()
        {
            CancelInvoke("BeginShake");
            transform.localPosition = Vector3.zero;
        }
    }
}