using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    private void Start()
    {
        //sonido
        StartCoroutine(Died());
    }

    private IEnumerator Died()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
