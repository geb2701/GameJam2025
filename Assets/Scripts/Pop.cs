using System.Collections;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public AudioClip destructionSound;

    private void Start()
    {
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
    private void PlayDestructionSound()
    {
        if (destructionSound != null)
        {
            // Crear un GameObject temporal
            GameObject tempAudioSource = new GameObject("Pop");
            AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();

            // Configurar el AudioSource
            audioSource.clip = destructionSound;
            audioSource.Play();

            // Destruir el objeto temporal después de que termine el sonido
            Destroy(tempAudioSource, destructionSound.length);
        }
    }

    private IEnumerator Died()
    {
        PlayDestructionSound();

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
