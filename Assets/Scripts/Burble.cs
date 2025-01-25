using System.Collections.Generic;
using UnityEngine;

public class Burble : MonoBehaviour
{
    public float speed = 1f;
    public int intensityForceLevel = -1;
    [SerializeField] protected LayerMask playerLayer;

    private bool goDown = false;
    private float initialX = 0;

    private float horizontalSpeed = 0;
    private float horizontalAmplitude = 0;

    [SerializeField] public bool stopMove = false;
    [SerializeField] protected GameObject pop;

    bool poping = false;

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
    protected virtual void Update()
    {
        if (stopMove) return;
        else
        {
            if (goDown)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }

            float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;
            transform.position = new Vector3(initialX + horizontalOffset, transform.position.y, transform.position.z);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer) != 0 && !poping)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(playerLayer.value);
        if ((1 << collision.gameObject.layer) != 0)
        {
            Debug.Log("down");
            goDown = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer) != 0)
        {
            poping = true;
            collision.transform.SetParent(null);

            try
            {
                GameObject objetoPadre = gameObject?.transform?.parent?.gameObject;
                Transform[] hijos;
                if (objetoPadre != null)
                {
                    hijos = objetoPadre.GetComponentsInChildren<Transform>();
                    foreach (Transform hijo in hijos)
                    {
                        if (hijo.gameObject.layer == playerLayer)
                        {
                            hijo.SetParent(null);
                        }
                    }
                }
                if (pop != null)
                {
                    GameObject newBurble = Instantiate(pop, gameObject.transform.position, Quaternion.identity);
                }

                hijos = gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform hijo in hijos)
                {
                    if (hijo.gameObject.layer == playerLayer)
                    {
                        hijo.SetParent(null);
                    }
                }
                Destroy(this.gameObject);
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }

        }
    }

    private class HorizontalMovementLevel
    {
        public float horizontalAmplitudeMin { get; set; }
        public float horizontalAmplitudeMax { get; set; }
        public float speedMin { get; set; }
        public float speedMax { get; set; }
    }
}
