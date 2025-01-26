using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class CollisionMessage : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Debug.Log("<color=#7df>¡Estás limpio!</color>");
            //SceneManager.LoadScene(1);
        }
    }
}
