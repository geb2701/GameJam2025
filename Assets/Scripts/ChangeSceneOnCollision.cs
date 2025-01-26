using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}