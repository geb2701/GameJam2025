using System.Collections;
using UnityEngine;

public class Burble : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private LayerMask playerLayer;

    private bool goDown = false;
    private Coroutine activeCoroutine;
    void Update()
    {
        if (goDown)
        {
            transform.position -= Vector3.up * (speed / 2) * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Transform playerTransform = collision.transform;
            Transform platformTransform = transform;
            float platformBottomY = platformTransform.position.y - (platformTransform.localScale.y / 2);

            if (playerTransform.position.y > platformBottomY)
            {
                goDown = true;
                StopCoroutine(CountdownAndGoDown());
                StartCoroutine(CountdownAndGoDown());
            }
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            goDown = true;
            if (activeCoroutine != null)
            {
                StopCoroutine(activeCoroutine);
            }

            activeCoroutine = StartCoroutine(CountdownAndGoDown());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            collision.transform.SetParent(null);
            StopCoroutine(CountdownAndGoDown());
            StartCoroutine(CountdownAndGoDown());
        }
    }
    private IEnumerator CountdownAndGoDown()
    {
        yield return new WaitForSeconds(2f);
        goDown = false;
        activeCoroutine = null;
    }
}
