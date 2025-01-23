using UnityEngine;

public class CollisionDestroyer : MonoBehaviour
{
    [SerializeField] private LayerMask[] layerToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (LayerMask layer in layerToDestroy)
        {
            if ((layer.value & (1 << collision.gameObject.layer)) != 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}