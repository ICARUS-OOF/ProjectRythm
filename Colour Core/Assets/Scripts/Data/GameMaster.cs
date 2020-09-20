using ColourCore.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColourCore
{
    namespace Data
    {
        public class GameMaster : MonoBehaviour
        {
            #region Object system
            public static GameMaster singleton;
            private void Awake()
            {
                GameMaster[] objs = GameObject.FindObjectsOfType<GameMaster>();
                if (objs.Length > 1)
                {
                    Destroy(this.gameObject);
                    return;
                } else
                {
                    DontDestroyOnLoad(this.gameObject);
                }
                if (singleton == null)
                {
                    singleton = this;
                }
            }
            #endregion
            #region Preferences
            public float volume = 1f;
            #endregion
            #region LateUpdate Method
            private void LateUpdate()
            {
                if (MenuHandler.singleton != null)
                {
                    volume = MenuHandler.singleton.volumeSlider.value;
                }
                SetAudioVolume();

            }
            #endregion
            #region Util Methods
            void SetAudioVolume()
            {
                AudioSource[] sources = GameObject.FindObjectsOfType<AudioSource>();
                for (int i = 0; i < sources.Length; i++)
                {
                    sources[i].volume = volume / 2;
                }
            }
            #endregion
        }
    }
}