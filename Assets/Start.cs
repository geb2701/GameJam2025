using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : StateMachineBehaviour
{
    public AudioManager audioManager;
    public void Jugar()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
        SceneManager.LoadScene(1);
    }
}
