using ColourCore.Handlers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace ColourCore
{
    namespace Data
    {
        public class PlayerData : MonoBehaviour
        {
            [Header("Prime Variables")]
            public bool canDamage = true;
            public int Health = 4;
            [Header("References")]
            public Slider healthBarSlider;
            private void Start()
            {
                healthBarSlider.maxValue = Health;
            }
            private void LateUpdate()
            {
                healthBarSlider.value = Health;
            }
            public void Damage()
            {
                if (!canDamage)
                { return; }
                SoundHandler.singleton.PlaySound("Hit", 2f);
                StartCoroutine(DamageCooldown());
                StartCoroutine(Flash());
                Health--;
                if (Health <= 0)
                {
                    StartCoroutine(Defeated());
                }
            }
            IEnumerator Defeated()
            {
                StartCoroutine(GameMaster.singleton.LerpTimescale(0f));
                GameHandler.singleton.transitionOut.enabled = true;
                yield return new WaitForSecondsRealtime(2f);
                GameMaster.ReloadScene();
            }
            IEnumerator Flash()
            {
                GameHandler.singleton.flashPanel.SetActive(true);
                yield return new WaitForSeconds(0.011f);
                GameHandler.singleton.flashPanel.SetActive(false);
            }
            IEnumerator DamageCooldown()
            {
                canDamage = false;
                yield return new WaitForSeconds(2f);
                canDamage = true;
            }
            private void Update()
            {
            
            }
        }
    }
}
