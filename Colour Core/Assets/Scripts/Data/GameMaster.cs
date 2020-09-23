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
            #region Properties
            public string previousRootScene = "";
            #endregion
            #region Start
            private void Start()
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
                OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
            }
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
            #region Event Subscribers
            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                Time.timeScale = 1f;
                if (GameHandler.singleton == null)
                {
                    previousRootScene = scene.name;
                }
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
            public IEnumerator LerpTimescale(float _time)
            {
                for ( ; ; )
                {
                    Time.timeScale = Mathf.Lerp(Time.timeScale, _time, Time.unscaledDeltaTime * 4f);
                    for (int i = 0; i < GetAudioSources().Length; i++)
                    {
                        GetAudioSources()[i].pitch = Mathf.Lerp(GetAudioSources()[i].pitch, _time, Time.unscaledDeltaTime * 3f);
                    }
                    yield return null;
                }
            }
            public AudioSource[] GetAudioSources()
            {
                return FindObjectsOfType<AudioSource>();
            }
            #endregion
            #region Static Utils Methods
            public static void ReloadScene()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            #endregion
        }
    }
}