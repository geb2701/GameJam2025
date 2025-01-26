using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXsource;



    [Header("--------Audio Clip--------")]

    public AudioClip Background_Menu;
    public AudioClip Background_Anim;
    public AudioClip Background_Juego;

    public AudioClip Background_End;



    public AudioClip baniaderaLlenandose;
    public AudioClip Explota_Chica_1;
    public AudioClip Explota_Chica_2;
    public AudioClip Explota_Grande_1;
    public AudioClip Explota_Grande_2;
    public AudioClip Explota_Mediana_1;
    public AudioClip Explota_Mediana_2;
    public AudioClip Scrolling_1;
    public AudioClip Scrolling_2;

    public AudioClip Salto_1_I;
    public AudioClip Salto_1_D;

    public AudioClip Salto_2_I;
    public AudioClip Salto_2_D;

    public AudioClip Salto_3_I;
    public AudioClip Salto_3_D;

    public AudioClip Salto_Burbuja_1;
    public AudioClip Salto_Burbuja_2;
    public AudioClip Salto_Burbuja_3;

    public AudioClip CaeAlAgua;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        musicSource.loop = true;
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);

    }

}
