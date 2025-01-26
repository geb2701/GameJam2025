using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public AudioManager audioManager;

    private List<AudioClip> audioList = new List<AudioClip>();
    private void Start()
    {
        audioManager = AudioManager.Instance;
        if (audioManager != null)
        {
            audioList = new()
            {
                audioManager.Explota_Chica_1,
                audioManager.Explota_Chica_2,
                audioManager.Explota_Grande_1,
                audioManager.Explota_Grande_2,
                audioManager.Explota_Mediana_1,
                audioManager.Explota_Mediana_2,
            };
        }

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
        if (audioManager != null)
            audioManager.PlaySFX(audioList[Random.Range(0, audioList.Count - 1)]);

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
