using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;




[System.Serializable]
public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI talkingText;
    public LocalizedString[] myStrings;
    public int dialSpeed;
    public int whichStringCurrently = 0;
    public Animator dialogueAnimator;
    private bool _start = true;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (_start)
            {
                dialogueAnimator.SetTrigger("entry");
                _start = false;
            }
            else
            {
                NextSentence();
            }
        }

    }

    void NextSentence()
    {
        if (whichStringCurrently <= myStrings.Length - 1)
        {
            //initialTimer = 1;
            talkingText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogueAnimator.SetTrigger("exit");
        }
        //nextString = true;
        whichStringCurrently++;
    }

    IEnumerator WriteSentence()
    {
        talkingText.text = myStrings[whichStringCurrently].GetLocalizedString();
        yield return new WaitForSeconds(dialSpeed);
        /*foreach (char Character in sentence.ToCharArray())
        {
            talkingText.text += Character;
            yield return new WaitForSeconds(dialSpeed);
        }*/
    }
}
