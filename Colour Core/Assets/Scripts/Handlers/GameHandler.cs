using ColorCore.Enumerations;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ColorCore
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
            #region Singleton
            public static GameHandler singleton;
            private void Awake()
            {
                if (singleton == null)
                {
                    singleton = this;
                }
            }
            #endregion
            #region Level Settings
            public CorruptColour playerCorruptColour;
            public string musicName, musicAuthor;
            public TMP_Text nameText, authorText;
            #endregion
            #region Start Method
            private void Start()
            {
                onChangeCorruptColour += OnChangeCorruptColour;
                nameText.text = musicName;
                authorText.text = musicAuthor;
            }
            #endregion
            #region Events
            public EventHandler onChangeCorruptColour; 
            void OnChangeCorruptColour(object sender, EventArgs e)
            {
                playerCorruptColour = GetOppositeCorruptColour(playerCorruptColour);
            }
            #endregion
            #region Util Functions
            public void ChangeCorruptColour()
            {
                onChangeCorruptColour?.Invoke(this, EventArgs.Empty);
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