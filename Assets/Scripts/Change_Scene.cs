using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public void ChangeToScene()
    {
        SceneManager.LoadScene(4);
    }
}