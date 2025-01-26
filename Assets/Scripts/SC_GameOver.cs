using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class SC_GameOver : MonoBehaviour
{
    private AudioManager audioManager;
    public SpriteRenderer inlges;
    public SpriteRenderer español;

    private void Start()
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
    public void Jugar()
    {
        SceneManager.LoadScene("Level_Scene");
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Menu;
        audioManager.musicSource.Play();
    }
}
