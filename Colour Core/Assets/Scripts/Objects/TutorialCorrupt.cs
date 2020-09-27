using ColourCore.Enumerations;
using ColourCore.Handlers;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

namespace ColourCore
{
    namespace Movement
    {
        public class TutorialCorrupt : MonoBehaviour
        {
            [SerializeField] CorruptColour corruptColour;
            [SerializeField] GameObject shrinkObj;
            bool isTriggered = false;
            private void LateUpdate()
            {
                GetComponent<SpriteShapeRenderer>().color = GameHandler.GetCorrespondingColour(corruptColour);
            }
            private void OnTriggerStay2D(Collider2D col)
            {
                if (isTriggered)
                {
                    return;
                }
                if (col.transform.tag == "Player")
                {
                    if (corruptColour == GameHandler.singleton.playerCorruptColour)
                    {
                        StartCoroutine(shrink());
                        GameHandler.singleton.PlayMusic();
                        isTriggered = true;
                    }
                }
            }
            IEnumerator shrink()
            {
                while (true)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.fixedDeltaTime * 4f);
                    shrinkObj.transform.localScale = Vector3.Lerp(shrinkObj.transform.localScale, Vector3.zero, Time.fixedDeltaTime * 4f);
                    yield return null;
                }
            }
        }
    }
}
