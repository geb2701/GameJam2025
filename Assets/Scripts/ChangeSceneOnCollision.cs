using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private AsyncOperation asyncOperation;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        //StartCoroutine(PreloadScene());
    }
    private System.Collections.IEnumerator PreloadScene()
    {
        asyncOperation = SceneManager.LoadSceneAsync(2);
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
            audioManager.musicSource.Stop();
            audioManager.musicSource.clip = audioManager.Background_End;
            audioManager.musicSource.Play();
            Debug.Log("<color=#7df>Caiste al agua: </color><color=#f77>Game Over</color>");
            SceneManager.LoadScene(2);
        }
    }
}