using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene()
    {
        SceneManager.LoadScene(4);
    }
}