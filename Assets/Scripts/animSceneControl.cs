using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
public class animSceneControl : MonoBehaviour
{
public TextMeshProUGUI talkingText;
public Animator dialogueAnimator;
public DialogueController _keyCheck;
public AudioClip Maceta_Arrastra;
public AudioClip Maceta_Break;
public AudioClip Pasos;
public AudioClip Enojo;
public AudioManager _sfx;


    // Update is called once per frame
    void Update()
    {
        switch(_keyCheck.whichStringCurrently)
        {
            case 6:
            dialogueAnimator.SetTrigger("page2");
            break;
            
            case 21:
            _sfx.PlaySFX(Maceta_Arrastra);
            dialogueAnimator.SetTrigger("page3");
            break;

            case 22:
            _sfx.PlaySFX(Maceta_Break);
            break;

            case 36:
            _sfx.PlaySFX(Pasos);
            break;

            case 37:
            dialogueAnimator.SetTrigger("page4");
            _sfx.PlaySFX(Enojo);
            break;

            case 54:
            dialogueAnimator.SetTrigger("exit");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");

            break;

        }

        /*if(_keyCheck.whichStringCurrently == 6)
        {
            dialogueAnimator.SetTrigger("page2");

        }
        if(_keyCheck.whichStringCurrently == 21)
        {
            dialogueAnimator.SetTrigger("page3");
        }
        if(_keyCheck.whichStringCurrently == 37)
        {
            dialogueAnimator.SetTrigger("page4");

        }
        if(_keyCheck.whichStringCurrently == 54)
        {
            dialogueAnimator.SetTrigger("exit");

        }  */      

    }
}
