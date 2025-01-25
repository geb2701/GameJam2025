using System.Collections;
using UnityEngine;

public class TimeBurble : Burble
{
    public float lifeTime = 2;

    [SerializeField] private GameObject spriteStart;
    [SerializeField] private GameObject spriteMid;
    [SerializeField] private GameObject spriteEnd;
    [SerializeField] private GameObject spriteExplote;

    private bool isExploting = false;

    protected override void Start()
    {
        base.Start();
        SpriteRenderer burbleRenderStart = spriteStart.GetComponent<SpriteRenderer>();
        burbleRenderStart.enabled = true;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if ((1 << collision.gameObject.layer) != 0 && !isExploting)
        {
            isExploting = true;
            StartCoroutine(Died());
        }
    }

    private IEnumerator Died()
    {
        var timer = lifeTime / 3;
        SpriteRenderer burbleRender = spriteStart.GetComponent<SpriteRenderer>();

        yield return new WaitForSeconds(timer);

        burbleRender.enabled = false;
        burbleRender = spriteMid.GetComponent<SpriteRenderer>();
        burbleRender.enabled = true;

        yield return new WaitForSeconds(timer);

        burbleRender.enabled = false;
        burbleRender = spriteEnd.GetComponent<SpriteRenderer>();
        burbleRender.enabled = true;

        yield return new WaitForSeconds(timer);

        burbleRender.enabled = false;
        burbleRender = spriteExplote.GetComponent<SpriteRenderer>();
        burbleRender.enabled = true;

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        stopMove = true;
        GameObject objetoPadre = gameObject.transform.parent.gameObject;
        objetoPadre.GetComponent<Burble>().stopMove = true;

        float tiempoTranscurrido = 0f;
        float duracion = 0.7f;
        Vector3 escalaInicial = burbleRender.transform.localScale;
        Vector3 escalaObjetivo = escalaInicial * 2f;

        while (tiempoTranscurrido < duracion)
        {
            burbleRender.transform.localScale = Vector3.Lerp(escalaInicial, escalaObjetivo, tiempoTranscurrido / duracion);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        Destroy(objetoPadre);
    }
}