using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
[Header("--------Audio Source--------")]
[SerializeField] AudioSource musicSource;
[SerializeField] AudioSource SFXsource;



[Header ("--------Audio Clip--------")]

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



private void Start(){
    musicSource.clip = Background_Menu;
    musicSource.Play();

}

public void PlaySFX(AudioClip clip)
{
    SFXsource.PlayOneShot(clip);
    
}

}
