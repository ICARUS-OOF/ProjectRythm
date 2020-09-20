using ColourCore.Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace ColourCore
{
    namespace Handlers
    {
        public class MenuHandler : MonoBehaviour
        {
            private PanelType currentPanel;
            public GameObject menuPanel;
            public GameObject optionsPanel;
            public GameObject selectLevelPanel;

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
                        break;
                    case PanelType.Options:
                        menuPanel.SetActive(false);
                        optionsPanel.SetActive(true);
                        selectLevelPanel.SetActive(false);
                        break;
                    case PanelType.Select:
                        menuPanel.SetActive(false);
                        optionsPanel.SetActive(false);
                        selectLevelPanel.SetActive(true);
                        break;
                }
            }
            public void Play()
            {
                SceneManager.LoadScene("World");
            }
            public void SelectLevel()
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
        }
    }
}
