using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Killer")
        {
            Debug.Log("Game Over");
        }
    }
}
