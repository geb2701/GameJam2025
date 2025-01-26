using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        MainMenuButton();
    }

    public void Jugar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
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
    /*public void SetPatita(GameObject _gameObject)
    {
        patita = eventSelector.EventSystem.SetSelectedGameObject(_gameObject);

        

    }
*/
        
}



