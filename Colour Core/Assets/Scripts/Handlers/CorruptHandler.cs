using ColourCore.Enumerations;
using ColourCore.Objects;
using ColourCore.Serializables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace ColourCore
{
    namespace Handlers
    {
        public class CorruptHandler : MonoBehaviour
        {
            public List<CorruptMovement> corrupts = new List<CorruptMovement>();
            public List<TimedCorruptMovement> corruptsWithDuration = new List<TimedCorruptMovement>();
            public List<CorruptExplosion> explosions = new List<CorruptExplosion>();
            private void Start()
            {
                for (int i = 0; i < corrupts.Count; i++)
                {
                    StartCoroutine(TriggerCorrupt(corrupts[i]));
                }
                for (int i = 0; i < corruptsWithDuration.Count; i++)
                {
                    StartCoroutine(TriggerDurationCorrupt(corruptsWithDuration[i]));
                }
                for (int i = 0; i < explosions.Count; i++)
                {
                    StartCoroutine(TriggerExplosion(explosions[i]));
                }
            }
            IEnumerator TriggerCorrupt(CorruptMovement data)
            {
                data.objectToMove.SetActive(false);
                yield return new WaitForSeconds(data.delay);
                data.objectToMove.SetActive(true);
                for ( ; ; )
                {
                    data.objectToMove.GetComponent<Rigidbody2D>().velocity = (data.velocity * Time.deltaTime * 6f);
                    foreach (Transform t in data.objectToMove.transform)
                    {
                        if (t.GetComponent<Rigidbody2D>() != null)
                        {
                            t.GetComponent<Rigidbody2D>().velocity = (data.velocity * Time.deltaTime * 6f);
                        }
                    }
                    yield return null;
                }
            }
            IEnumerator TriggerDurationCorrupt(TimedCorruptMovement data)
            {
                data.objectToMove.SetActive(false);
                yield return new WaitForSeconds(data.delay);
                data.objectToMove.SetActive(true);
                data.isMoving = true;
                StartCoroutine(ResetCorruptDuration(data));
                while (data.isMoving)
                {
                    data.objectToMove.GetComponent<Rigidbody2D>().velocity = (data.velocity * Time.deltaTime * 6f);
                    foreach (Transform t in data.objectToMove.transform)
                    {
                        if (t.GetComponent<Rigidbody2D>() != null)
                        {
                            t.GetComponent<Rigidbody2D>().velocity = (data.velocity * Time.deltaTime * 6f);
                        }
                    }
                    yield return null;
                }
                data.objectToMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                foreach (Transform t in data.objectToMove.transform)
                {
                    if (t.GetComponent<Rigidbody2D>() != null)
                    {
                        t.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                }
            }
            IEnumerator ResetCorruptDuration(TimedCorruptMovement data)
            {
                yield return new WaitForSeconds(data.duration);
                data.isMoving = false;
            }
            IEnumerator TriggerExplosion(CorruptExplosion data)
            {
                data.sender.SetActive(false);
                yield return new WaitForSeconds(data.delay);
                data.sender.SetActive(true);
                CameraController.singleton.Shake(.2f, .2f);
                for (int i = 0; i < data.rate; i++)
                {
                    StartCoroutine(moveExplosionObj(data));
                }
            }
            IEnumerator moveExplosionObj(CorruptExplosion data)
            {
                GameObject obj = Instantiate(data.prefab, data.sender.transform.position, data.sender.transform.rotation);
                CorruptColour c = GameHandler.GetRandomCorruptColour();
                obj.GetComponent<Corrupt>().corruptColour = c;
                //Debug.Log(c);
                float Rnd_R = UnityEngine.Random.Range(0f, 360);
                obj.transform.Rotate(new Vector3(0f, 0f, Rnd_R));
                for ( ; ; )
                {
                    obj.transform.Translate(obj.transform.up * Time.deltaTime * data.speed);
                    yield return null;
                }
            }
        }
    }
}
