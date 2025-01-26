using UnityEngine;

public class BurblePlatform : MonoBehaviour
{
    public float speed = 0.7f;
    protected virtual void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.transform.SetParent(null);
        }
    }
}
