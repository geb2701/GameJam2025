using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystem;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuOpciones;
    public GameObject Creditos;
    public GameObject MenuAudio;
    public GameObject MenuIdioma;
    // public GameObject eventSelector;
    private AsyncOperation asyncOperation;

    public AudioManager audioManager;



    void Start()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Menu;
        audioManager.musicSource.Play();
        MainMenuButton();
        StartCoroutine(PreloadScene());
    }

    private System.Collections.IEnumerator PreloadScene()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void Jugar()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Juego;
        audioManager.musicSource.Play();
        SceneManager.LoadScene("Intro_Scene");
    }


    public void MainMenuButton()
    {
        Menu.SetActive(true);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(false);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void CreditsButton()
    {
        Menu.SetActive(false);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(true);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void OpcionesButton()
    {
        Menu.SetActive(false);
        MenuOpciones.SetActive(true);
        Creditos.SetActive(false);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void OpcionesAudio()
    {
        Menu.SetActive(false);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(false);
        MenuAudio.SetActive(true);
        MenuIdioma.SetActive(false);
    }
    public void OpcionesIdioma()
    {
        Menu.SetActive(false);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(false);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(true);
    }
    public void Salir()
    {
        Application.Quit();
    }

}



