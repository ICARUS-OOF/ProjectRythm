﻿using ColorCore.Enumerations;
using ColorCore.Objects;
using ColorCore.Serializables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace ColorCore
{
    namespace Handlers
    {
        public class CorruptHandler : MonoBehaviour
        {
            public List<CorruptMovement> corrupts = new List<CorruptMovement>();
            public List<CorruptExplosion> explosions = new List<CorruptExplosion>();
            private void Start()
            {
                for (int i = 0; i < corrupts.Count; i++)
                {
                    StartCoroutine(TriggerCorrupt(corrupts[i]));
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
            IEnumerator TriggerExplosion(CorruptExplosion data)
            {
                data.sender.SetActive(false);
                yield return new WaitForSeconds(data.delay);
                data.sender.SetActive(true);
                CameraController.singleton.Shake(.4f, .2f);
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
                    obj.transform.Translate(obj.transform.up * Time.deltaTime * data.particleSpeed);
                    yield return null;
                }
            }
        }
    }
}
