using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // Nombre de la escena de Game Over
    public string gameOverScene = "GameOver";

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Lleva a la escena de Game Over
            SceneManager.LoadScene(gameOverScene);
        }
    }
}
