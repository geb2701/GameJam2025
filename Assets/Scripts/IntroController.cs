using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using TMPro;

public class IntroController : MonoBehaviour
{
   // [SerializeField]    private LocalizedString localText;

   // [SerializeField]    private TextMeshProUGUI textComp;
    // Start is called before the first frame update
   // public LocalizedString[] lines;
   // public float textSpeed;
    //private int index;

    void Start()
    {
       /* textComp.text = string.Empty;
        StartDialogue();
        */
    }

    void Update()
    {
      /*  if(Input.anyKeyDown)
        {
            if(textComp.text == lines[index].GetLocalizedString)
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];

            }
        }*/
    }

  /*  void StartDialogue()
    {
        index = 0;
        StartCoroutine(Linea());

    }
    IEnumerator Linea()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if(index<lines.Length-1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(Linea());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    */
}
