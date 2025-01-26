using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameOver : MonoBehaviour
{
    public AudioManager audioManager;
    public void Jugar()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Menu;
        audioManager.musicSource.Play();
        SceneManager.LoadScene(0);
    }
}
