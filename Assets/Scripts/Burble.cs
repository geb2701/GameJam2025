using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burble : MonoBehaviour
{
    public float speed = 1f;
    public int intensityForceLevel = -1;
    [SerializeField] private LayerMask playerLayer;

    private bool goDown = false;
    private Coroutine activeCoroutine;

    private float horizontalAmplitude = 2f;
    private float horizontalSpeed = 1f;

    private List<HorizontalMovementLevels> horizontalMovementLevels = new List<HorizontalMovementLevels>()
    {
        new HorizontalMovementLevels()
        {

        },
    };
    private float initialX;

    private void Start()
    {
        if (intensityForceLevel > 0 && )
        {

        }
        var intensity = Random.Range(0, 10);
        if ()
            initialX = transform.position.x;
    }
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

        float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;
        transform.position = new Vector3(initialX + horizontalOffset, transform.position.y, transform.position.z);
    }

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

    private class HorizontalMovementLevels
    {
        public float horizontalAmplitudeMin { get; set; }
        public float horizontalAmplitudeMax { get; set; }
        public float horizontalSpeedMin { get; set; }
        public float horizontalSpeedMax { get; set; }
    }
}
