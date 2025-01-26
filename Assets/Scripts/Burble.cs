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

    protected bool poping = false;

    public float lifeTime = 15;

    [SerializeField] private GameObject spriteStart;
    [SerializeField] private GameObject spriteMid;
    [SerializeField] private GameObject spriteEnd;

    private bool isExploting = false;

    private float spriteChangeTimer = 0f; // Temporizador para cambio de sprite
    private int spriteStage = 0; // Etapa actual del sprite
    private float spriteInterval = 2f; // Intervalo de cambio de sprite

    private List<HorizontalMovementLevel> horizontalMovementLevels = new()
    {
        new () { horizontalAmplitudeMin = 0, horizontalAmplitudeMax = 0f, speedMin = 0, speedMax = 0f },
        new () { horizontalAmplitudeMin = 0.2f, horizontalAmplitudeMax = 0.6f, speedMin = 0.4f, speedMax = 0.7f },
        new () { horizontalAmplitudeMin = 0.4f, horizontalAmplitudeMax = 0.6f, speedMin = 0.6f, speedMax = 0.8f },
        new () { horizontalAmplitudeMin = 0.5f, horizontalAmplitudeMax = 0.8f, speedMin = 0.5f, speedMax = 1f },
    };

    protected void Start()
    {
        HorizontalMovementLevel horizontalMovement = SelectHorizontalMovementLevel();
        initialX = transform.position.x;
        horizontalSpeed = Random.Range(horizontalMovement.speedMin, horizontalMovement.speedMax);
        horizontalAmplitude = Random.Range(horizontalMovement.horizontalAmplitudeMin, horizontalMovement.horizontalAmplitudeMax);

        // Configurar temporizador de cambio de sprite
        spriteInterval = lifeTime / 3;
        ResetSprites();
    }

    protected virtual void Update()
    {
        if (!stopMove)
        {
            MoveBurble();
        }
        if (isExploting && !poping)
        {
            if (spriteChangeTimer >= spriteInterval)
            {
                ChangeSprite();
            }
            else
            {
                spriteChangeTimer += Time.deltaTime;
            }
        }

    }

    private void MoveBurble()
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            goDown = true;
            isExploting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision?.transform?.SetParent(null);

            if (!poping)
            {
                Pop();
            }

        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (!poping)
            {
                collision.transform.SetParent(transform);
            }
        }
    }
    private void ChangeSprite()
    {
        spriteChangeTimer = 0f; // Reiniciar el temporizador
        spriteStage++;

        switch (spriteStage)
        {
            case 1:
                spriteStart.GetComponent<SpriteRenderer>().enabled = false;
                spriteMid.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
                spriteMid.GetComponent<SpriteRenderer>().enabled = false;
                spriteEnd.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 3:
                Pop();
                break;
        }
    }

    private void ResetSprites()
    {
        spriteStart.GetComponent<SpriteRenderer>().enabled = true;
        spriteMid.GetComponent<SpriteRenderer>().enabled = false;
        spriteEnd.GetComponent<SpriteRenderer>().enabled = false;
    }

    protected void Pop()
    {
        poping = true;
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
            spriteStart.GetComponent<SpriteRenderer>().enabled = false;
            spriteMid.GetComponent<SpriteRenderer>().enabled = false;
            spriteEnd.GetComponent<SpriteRenderer>().enabled = false;
            BoxCollider2D boxCollider2D;
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            if (boxCollider2D != null)
            {
                boxCollider2D.enabled = false;
            }
            boxCollider2D = gameObject.GetComponentInChildren<BoxCollider2D>();
            if (boxCollider2D != null)
            {
                boxCollider2D.enabled = false;
            }
            isExploting = true;
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    private HorizontalMovementLevel SelectHorizontalMovementLevel()
    {
        var intensity = Random.Range(0, 10);
        HorizontalMovementLevel horizontalMovement = null;

        if (intensityForceLevel > 0 && intensityForceLevel <= horizontalMovementLevels.Count)
        {
            horizontalMovement = horizontalMovementLevels[intensityForceLevel];
        }
        else
        {
            if (intensity > 5) horizontalMovement = horizontalMovementLevels[0];
            else if (intensity > 7) horizontalMovement = horizontalMovementLevels[1];
            else if (intensity > 9) horizontalMovement = horizontalMovementLevels[2];
            else horizontalMovement = horizontalMovementLevels[3];
        }

        return horizontalMovement ?? horizontalMovementLevels[0];
    }

    private class HorizontalMovementLevel
    {
        public float horizontalAmplitudeMin { get; set; }
        public float horizontalAmplitudeMax { get; set; }
        public float speedMin { get; set; }
        public float speedMax { get; set; }
    }
}
