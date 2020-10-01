using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColourCore.Handlers
{
    public class PlayerUI : MonoBehaviour
    {
        #region Singleton
        public static PlayerUI singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        [Header("UI Variables")]
        public bool isPaused = false;
        [Header("References")]
        public GameObject pauseMenuUI;
        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
            }
            pauseMenuUI.SetActive(isPaused);
            if (isPaused)
            {
                GameHandler.singleton.Music.Pause();
                Time.timeScale = 0f;
            }
            else
            {
                GameHandler.singleton.Music.UnPause();
                Time.timeScale = 1f;
            }
        }
        public void Resume()
        {
            isPaused = false;
        }
        public void Exit()
        {
            isPaused = false;
            Time.timeScale = 1f;
            StartCoroutine(GameHandler.singleton.LoadRootScene(0f));
        }
    }
}