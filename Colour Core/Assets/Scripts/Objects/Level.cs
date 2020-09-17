using ColourCore.Handlers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColourCore
{
    namespace Objects
    {
        public class Level : MonoBehaviour
        {
            public TMP_Text titleText, artistText;
            public GameObject mainSprite;
            public GameObject inner;
            public GameObject ID;
            public GameObject transition;
            public string musicName, artist;
            private void Start()
            {
                titleText.text = musicName;
                artistText.text = artist;
                ID.transform.localScale = new Vector3(0f, ID.transform.localScale.y, ID.transform.localScale.z);
                inner.transform.localScale = new Vector3(0f, 0f, transform.localScale.z);

            }
            private void Update()
            {
                mainSprite.transform.Rotate(new Vector3(0f, 0f, GameHandler.LevelSpinSpeed * Time.deltaTime));

                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GameHandler.levelRange);
                foreach (Collider2D col in colliders)
                {
                    if (col.transform.tag == "Player")
                    {
                        inner.transform.localScale = Vector3.Lerp(inner.transform.localScale, new Vector3(0.5f, 0.5f, inner.transform.localScale.z), GameHandler.LevelExpandSpeed * Time.deltaTime);
                        mainSprite.transform.localScale = Vector3.Lerp(mainSprite.transform.localScale, new Vector3(1.65f, 1.65f), GameHandler.LevelExpandSpeed * Time.deltaTime);

                        ID.transform.localScale = Vector3.Lerp(ID.transform.localScale, new Vector3(2f, ID.transform.localScale.y), GameHandler.LevelIDExpandSpeed * Time.deltaTime);

                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine(OnEnterEnterLevel());
                        }
                        return;
                    }
                }

                inner.transform.localScale = Vector3.Lerp(inner.transform.localScale, new Vector3(0f, 0f, inner.transform.localScale.z), GameHandler.LevelExpandSpeed * Time.deltaTime);
                mainSprite.transform.localScale = Vector3.Lerp(mainSprite.transform.localScale, new Vector3(1f, 1f), GameHandler.LevelExpandSpeed * Time.deltaTime);
                ID.transform.localScale = Vector3.Lerp(ID.transform.localScale, new Vector3(0f, 1f, 2f), GameHandler.LevelIDExpandSpeed * Time.deltaTime);
            }
            IEnumerator OnEnterEnterLevel()
            {
                SoundHandler.singleton.PlaySound("Select 1");
                transition.SetActive(true);
                yield return new WaitForSeconds(2f);
                Debug.Log("Loading " + musicName + "...");
                SceneManager.LoadScene(musicName);
            }
        }
    }
}
