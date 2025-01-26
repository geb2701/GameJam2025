using System.Collections;
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
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            audioManager.PlaySFX(audioManager.CaeAlAgua);
            collider.GetComponent<Movement>().canMove = false;
            StartCoroutine(LoadScene(1.5f));
        }
    }
    private IEnumerator LoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        audioManager.musicSource.Stop();
        audioManager.musicSource.clip = audioManager.Background_End;
        audioManager.musicSource.Play();
        Debug.Log("<color=#7df>Caiste al agua: </color><color=#f77>Game Over</color>");
        SceneManager.LoadScene(2);
    }

}