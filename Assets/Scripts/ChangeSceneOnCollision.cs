using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private AsyncOperation asyncOperation;
    private void Start()
    {
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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            SceneManager.LoadScene(1);
        }
    }
}