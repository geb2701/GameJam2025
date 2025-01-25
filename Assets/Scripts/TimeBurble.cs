using System.Collections;
using UnityEngine;

public class TimeBurble : Burble
{
    public float lifeTime = 15;

    [SerializeField] private GameObject spriteStart;
    [SerializeField] private GameObject spriteMid;
    [SerializeField] private GameObject spriteEnd;

    private bool isExploting = false;

    protected new void Start()
    {
        base.Start();
        SpriteRenderer burbleRenderStart = spriteStart.GetComponent<SpriteRenderer>();
        burbleRenderStart.enabled = true;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //base.OnCollisionEnter2D(collision);
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

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        stopMove = true;
        GameObject objetoPadre = gameObject.transform.parent.gameObject;
        objetoPadre.GetComponent<Burble>().stopMove = true;

        if (!poping)
        {
            Pop();
            poping = true;
        }
    }
}