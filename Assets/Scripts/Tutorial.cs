using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Tutorial : MonoBehaviour
    {
        public SpriteRenderer inlges;
        public SpriteRenderer español;
        public AudioManager audioManager;
        void Start()
        {
            audioManager = AudioManager.Instance;
            var systemLanguage = LocalizationSettings.SelectedLocale.LocaleName;
            if (systemLanguage.Contains("Spanish"))
            {
                español.enabled = true;
                inlges.enabled = false;
            }
            else
            {
                inlges.enabled = true;
                español.enabled = false;
            }
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                audioManager.musicSource.Stop();
                audioManager.musicSource.clip = audioManager.Background_Juego;
                audioManager.musicSource.Play();
                SceneManager.LoadScene("Level_Scene");
            }
        }
    }
}
