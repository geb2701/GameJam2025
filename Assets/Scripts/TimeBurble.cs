using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBurble:Burble
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
        Debug.Log("start");
        SpriteRenderer burbleRenderStart = spriteStart.GetComponent<SpriteRenderer>();
        burbleRenderStart.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0 && !isExploting)
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

        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        this.gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;


        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
