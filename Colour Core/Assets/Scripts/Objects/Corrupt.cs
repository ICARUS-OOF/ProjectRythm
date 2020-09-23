using ColourCore.Data;
using ColourCore.Enumerations;
using ColourCore.Handlers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
namespace ColourCore
{
    namespace Objects
    {
        public class Corrupt : MonoBehaviour
        {
            public CorruptColour corruptColour;
            private void OnTriggerStay2D(Collider2D col)
            {
                if (!GetComponent<Collider2D>().enabled)
                {
                    return;
                }
                GameHandler handler = GameHandler.singleton;
                if (col.transform.tag == "Player" && corruptColour != handler.playerCorruptColour)
                {
                    PlayerData data = col.GetComponent<PlayerData>();
                    if (!data.canDamage)
                    { return; }
                    GameObject particles = Instantiate(GameHandler.singleton.hitParticles, col.transform.position + new Vector3(0, 0, -1f), Quaternion.identity);
                    Destroy(particles, 3f);
                    StartCoroutine(DisableCollider());
                    data.Damage();
                }
            }
            private void Update()
            {
                GetComponent<SpriteShapeRenderer>().color = GameHandler.GetCorrespondingColour(corruptColour);
            }
            IEnumerator DisableCollider()
            {
                GetComponent<Collider2D>().enabled = false;
                yield return new WaitForSeconds(2f);
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
