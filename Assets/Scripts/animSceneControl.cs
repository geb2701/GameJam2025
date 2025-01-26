using TMPro;
using UnityEngine;
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


    private bool sound1 = true;
    private bool sound2 = true;
    private bool sound3 = true;
    private bool sound4 = true;

    private void Start()
    {
        _sfx = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_keyCheck.whichStringCurrently)
        {
            case 6:
                dialogueAnimator.SetTrigger("page2");
                break;

            case 20:
                if (sound1)
                {
                    _sfx.PlaySFX(Maceta_Arrastra);
                    dialogueAnimator.SetTrigger("page3");
                    sound1 = false;
                }
                break;

            case 21:
                if (sound2)
                {
                    _sfx.PlaySFX(Maceta_Break);
                    sound2 = false;
                }
                break;

            case 36:
                if (sound3)
                {
                    _sfx.PlaySFX(Pasos);
                    sound3 = false;
                }
                break;

            case 37:
                if (sound4)
                {
                    _sfx.PlaySFX(Enojo);
                    dialogueAnimator.SetTrigger("page4");
                    sound4 = false;
                }
                break;

            case 54:
                dialogueAnimator.SetTrigger("exit");
                UnityEngine.SceneManagement.SceneManager.LoadScene(4);

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
