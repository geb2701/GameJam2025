using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameOver : MonoBehaviour
{
    public AudioManager audioManager;
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
