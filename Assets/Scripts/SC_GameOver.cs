using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class SC_GameOver : MonoBehaviour
{
    public AudioManager audioManager;
    public SpriteRenderer inlges;
    public SpriteRenderer espa�ol;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        var systemLanguage = LocalizationSettings.SelectedLocale.LocaleName;
        if (systemLanguage.Contains("Spanish"))
        {
            espa�ol.enabled = true;
            inlges.enabled = false;
        }
        else
        {
            inlges.enabled = true;
            espa�ol.enabled = false;
        }
    }
    public void Jugar()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
        SceneManager.LoadScene("Level_Scene");
    }

    public void Menu()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Menu;
        audioManager.musicSource.Play();
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}
