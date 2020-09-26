using ColourCore.Data;
using ColourCore.Enumerations;
using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace ColourCore
{
    namespace Handlers
    {
        public class GameHandler : MonoBehaviour
        {
            #region Settings
            public static float LevelSpinSpeed = 100f;
            public static float LevelExpandSpeed = 7f;
            public static float LevelIDExpandSpeed = 10f;
            public static float levelRange = 1f;
            public static float HealthItemsRotateSpeed = 100f;
            #endregion
            #region Properties
            public GameObject hitParticles;
            #endregion
            #region Singleton and Awake Method
            public static GameHandler singleton;
            private void Awake()
            {
                if (singleton == null)
                {
                    singleton = this;
                }
                if (!autoPlay)
                {
                    GetComponent<CorruptHandler>().enabled = false;
                }
            }
            #endregion
            #region Level Properties
            public CorruptColour playerCorruptColour;
            public Animator transitionOut;
            public bool autoPlay = true;
            public float delay = 3.3f;
            public float songDuration = 107f;
            [HideInInspector]
            public AudioSource Music;
            public string musicName, musicAuthor;
            public TMP_Text nameText, authorText;
            public GameObject flashPanel;
            #endregion
            #region Start Method
            private void Start()
            {
                onChangeCorruptColour += OnChangeCorruptColour;
                onFinishLevel += OnFinishLevel;
                nameText.text = musicName;
                authorText.text = "by " + musicAuthor;
                Music = GetComponent<AudioSource>();
                StartCoroutine(StartMusic(delay)); 
            }
            #endregion
            #region Events
            public EventHandler onChangeCorruptColour;
            public EventHandler onFinishLevel;
            #endregion
            #region Event Subscribers
            void OnChangeCorruptColour(object sender, EventArgs e)
            {
                playerCorruptColour = GetOppositeCorruptColour(playerCorruptColour);
            }
            void OnFinishLevel(object sender, EventArgs e)
            {
                transitionOut.enabled = true;
                StartCoroutine(LoadRootScene(2.2f));
            }
            #endregion
            #region Main Methods
            IEnumerator StartMusic(float _delay)
            {
                if (!autoPlay)
                {
                    GetComponent<CorruptHandler>().enabled = true;
                }
                yield return new WaitForSeconds(_delay);
                if (autoPlay)
                {
                    PlayMusic();
                }
            }
            public void PlayMusic()
            {
                Debug.Log("Playing music...");
                Music.Play();
                StartCoroutine(AudioFadeOut(songDuration));
            }
            #endregion
            #region Util Functions
            public void ChangeCorruptColour()
            {
                onChangeCorruptColour?.Invoke(this, EventArgs.Empty);
            }
            public IEnumerator LoadRootScene(float delay)
            {
                yield return new WaitForSeconds(delay);
                SceneManager.LoadScene(GameMaster.singleton.previousRootScene);
            }
            public IEnumerator AudioFadeOut(float duration)
            {
                yield return new WaitForSeconds(duration);

                while (Music.volume != 0)
                {
                    Music.volume = Mathf.Lerp(Music.volume, 0f, Time.deltaTime * 3f);
                    yield return null;
                }
            }
            #endregion
            #region Static Util Functions
            public static CorruptColour GetOppositeCorruptColour(CorruptColour c)
            {
                if (c == CorruptColour.Blue)
                {
                    return CorruptColour.Red;
                }
                else
                {
                    return CorruptColour.Blue;
                }
            }
            public static Color GetCorrespondingColour(CorruptColour c)
            {
                if (c == CorruptColour.Blue)
                {
                    return Color.blue;
                }
                else
                {
                    return Color.red;
                }
            }
            public static CorruptColour GetRandomCorruptColour()
            {
                CorruptColour c;
                int Rnd_Int = UnityEngine.Random.Range(-1, 2);
                if (Rnd_Int == 0)
                {
                    c = CorruptColour.Blue;
                }
                else
                {
                    c = CorruptColour.Red;
                }
                return c;
            }
            #endregion
        }
    }
}