using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
}