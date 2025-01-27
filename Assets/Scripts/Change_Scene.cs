using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public void ChangeToScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
}