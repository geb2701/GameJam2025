using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burble : MonoBehaviour
{
    public float speed = 1f;
    public int intensityForceLevel = -1;
    [SerializeField] protected LayerMask playerLayer;

    private bool goDown = false;
    private float initialX = 0;
    private Coroutine activeCoroutine;

    private float horizontalSpeed = 0;
    private float horizontalAmplitude = 0;

    private List<HorizontalMovementLevel> horizontalMovementLevels = new()
    {
        new ()
        {
            horizontalAmplitudeMin = 0,
            horizontalAmplitudeMax = 0f,
            speedMin = 0,
            speedMax = 0f
        },
        new ()
        {
            horizontalAmplitudeMin = 0.2f,
            horizontalAmplitudeMax = 0.6f,
            speedMin = 0.4f,
            speedMax = 0.7f
        },
        new ()
        {
            horizontalAmplitudeMin = 0.4f,
            horizontalAmplitudeMax = 0.6f,
            speedMin = 0.6f,
            speedMax = 0.8f
        },
        new ()
        {
            horizontalAmplitudeMin = 0.5f,
            horizontalAmplitudeMax = 0.8f,
            speedMin = 0.5f,
            speedMax = 1f
        },
    };

    protected virtual void Start()
    {
        var intensity = Random.Range(0, 10);
        HorizontalMovementLevel horizontalMovement = null;
        if (intensityForceLevel > 0 && intensityForceLevel <= horizontalMovementLevels.Count)
        {
            horizontalMovement = horizontalMovementLevels[intensityForceLevel];
        }

        if (horizontalMovement == null)
        {
            if (intensity > 5)
            {
                horizontalMovement = horizontalMovementLevels[0];
            }
            else if (intensity > 7)
            {
                horizontalMovement = horizontalMovementLevels[1];
            }
            else if (intensity > 9)
            {
                horizontalMovement = horizontalMovementLevels[2];
            }
            else
            {
                horizontalMovement = horizontalMovementLevels[3];
            }
        }
        else
        {
            horizontalMovement = horizontalMovementLevels[0];
        }
        initialX = transform.position.x;
        horizontalSpeed = Random.Range(horizontalMovement.speedMin, horizontalMovement.speedMax);
        horizontalAmplitude = Random.Range(horizontalMovement.horizontalAmplitudeMin, horizontalMovement.horizontalAmplitudeMax);
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

    private class HorizontalMovementLevel
    {
        public float horizontalAmplitudeMin { get; set; }
        public float horizontalAmplitudeMax { get; set; }
        public float speedMin { get; set; }
        public float speedMax { get; set; }
    }
}
