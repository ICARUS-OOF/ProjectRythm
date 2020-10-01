using ColourCore.Enumerations;
using ColourCore.Handlers;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ColourCore.Objects
{
    public class Level : MonoBehaviour, IPointerEnterHandler
    {
        public AudioClip musicClip;
        public Text titleText, artistText;
        public Image iconRef, strip;
        public Sprite iconTexture;
        public string title, artist;
        public Difficulty difficulty;
        public void Start()
        {
            titleText.text = title;
            artistText.text = artist;
            iconRef.sprite = iconTexture;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    strip.color = Color.green;
                    break;
                case Difficulty.Medium:
                    strip.color = Color.yellow;
                    break;
                case Difficulty.Hard:
                    strip.color = Color.red;
                    break;
                case Difficulty.Insane:
                    strip.color = Color.magenta;
                    break;
                case Difficulty.Impossible:
                    strip.color = Color.black;
                    break;
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            MenuHandler.singleton.audioSource.clip = musicClip;
            MenuHandler.singleton.audioSource.Play();
        }
        public void PlayLevel()
        {
            MenuHandler.singleton.SetLevelInspector(title, artist, iconTexture, difficulty);
        }
    }
}