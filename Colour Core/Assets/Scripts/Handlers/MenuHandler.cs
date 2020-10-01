using ColourCore.Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
namespace ColourCore.Handlers
{
    public class MenuHandler : MonoBehaviour
    {
        public GameObject FadeOut;
        public AudioSource audioSource;
        private PanelType currentPanel;
        public GameObject menuPanel, optionsPanel, selectLevelPanel, levelInspector;

        [Header("Level Panel")]
        public Image iconImage;
        public Text MusicNameText, ArtistNameText, DifficultyText;

        #region Singleton
        public static MenuHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion

        //Options
        public Slider volumeSlider;
        private void Start()
        {
            currentPanel = PanelType.Menu;
        }
        private void Update()
        {
            switch (currentPanel)
            {
                case PanelType.Menu:
                    menuPanel.SetActive(true);
                    optionsPanel.SetActive(false);
                    selectLevelPanel.SetActive(false);
                    levelInspector.SetActive(false);
                    break;
                case PanelType.Options:
                    menuPanel.SetActive(false);
                    optionsPanel.SetActive(true);
                    selectLevelPanel.SetActive(false);
                    levelInspector.SetActive(false);
                    break;
                case PanelType.Select:
                    menuPanel.SetActive(false);
                    optionsPanel.SetActive(false);
                    selectLevelPanel.SetActive(true);
                    levelInspector.SetActive(false);
                    break;
                case PanelType.LevelInspector:
                    menuPanel.SetActive(false);
                    optionsPanel.SetActive(false);
                    selectLevelPanel.SetActive(false);
                    levelInspector.SetActive(true);
                    break;
            }
        }
        public void Play()
        {
            currentPanel = PanelType.Select;
        }
        public void Options()
        {
            currentPanel = PanelType.Options;
        }
        public void Quit()
        {
            Debug.Log("Quitting Application");
            Application.Quit();
        }
        public void SetLevelInspector(string musicName, string musicArtist, Sprite _icon, Difficulty difficulty)
        {
            currentPanel = PanelType.LevelInspector;
            MusicNameText.text = musicName;
            ArtistNameText.text = "by " + musicArtist;
            iconImage.sprite = _icon;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    DifficultyText.text = "Difficulty: [ <color=lime>" + difficulty.ToString() + "</color> ]";
                    break;
                case Difficulty.Medium:
                    DifficultyText.text = "Difficulty: [ <color=yellow>" + difficulty.ToString() + "</color> ]";
                    break;
                case Difficulty.Hard:
                    DifficultyText.text = "Difficulty: [ <color=red>" + difficulty.ToString() + "</color> ]";
                    break;
                case Difficulty.Insane:
                    DifficultyText.text = "Difficulty: [ <color=magenta>" + difficulty.ToString() + "</color> ]";
                    break;
                case Difficulty.Impossible:
                    DifficultyText.text = "Difficulty: [ <color=black>" + difficulty.ToString() + "</color> ]";
                    break;
            }
        }
        public void PlaySelectedLevel()
        {
            FadeOut.SetActive(true);
            StartCoroutine(LoadScene());
        }
        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(MusicNameText.text);
        }
        public void BackToMenu()
        {
            currentPanel = PanelType.Menu;
        }
    }
}