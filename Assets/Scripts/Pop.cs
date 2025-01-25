using System.Collections;
using UnityEngine;

public class Pop : MonoBehaviour
{
    private void Start()
    {
        //sonido
        StartCoroutine(Died());
    }

    private void Update()
    {
        //Vector3 previousScale = transform.localScale;

        transform.localScale += Vector3.one * 0.1f * Time.deltaTime;
        /*
        Vector3 scaleDifference = transform.localScale - previousScale;

        transform.position -= scaleDifference / 2;*/
    }

    private IEnumerator Died()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
