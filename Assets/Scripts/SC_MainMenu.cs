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
    public SpriteRenderer titulo;


    void Start()
    {
        audioManager = AudioManager.Instance;
        titulo.enabled = true;
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Menu;
        audioManager.musicSource.Play();
        MainMenuButton();
    }

    public void Jugar()
    {
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_Anim;
        audioManager.musicSource.Play();
        SceneManager.LoadScene(3);
    }


    public void MainMenuButton()
    {
        titulo.enabled = true;
        Menu.SetActive(true);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(false);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void CreditsButton()
    {

        titulo.enabled = false;
        Menu.SetActive(false);
        MenuOpciones.SetActive(false);
        Creditos.SetActive(true);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void OpcionesButton()
    {
        titulo.enabled = true;
        Menu.SetActive(false);
        MenuOpciones.SetActive(true);
        Creditos.SetActive(false);
        MenuAudio.SetActive(false);
        MenuIdioma.SetActive(false);
    }

    public void OpcionesAudio()
    {
        titulo.enabled = false;
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



