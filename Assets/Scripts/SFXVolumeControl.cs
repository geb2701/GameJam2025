using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SFXVolumeControl : MonoBehaviour
{
    public AudioSource audioSource; // Asigna tu AudioSource en el Inspector
    public Slider volumeSlider; // Asigna el slider en el Inspector

    private bool isPlaying = false; // Para evitar que múltiples corrutinas se ejecuten simultáneamente

    void Start()
    {
        if (audioSource != null && volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    void OnSliderValueChanged(float value)
    {
        if (!isPlaying)
        {
            StartCoroutine(PlaySoundWithDelay(2f)); // Inicia la corrutina con un retraso de 2 segundos
        }
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        isPlaying = true;

        // Asegúrate de que el sonido se reproduce al ajustar el slider
        if (audioSource != null)
        {
            audioSource.volume = volumeSlider.value;
            audioSource.Play();
        }

        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        isPlaying = false;
    }
}