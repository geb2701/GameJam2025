using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Star : MonoBehaviour
{
    public AudioManager audioManager;
    public void Jugar()
    {
        SceneManager.LoadScene("Level_Scene");
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
    }
}
