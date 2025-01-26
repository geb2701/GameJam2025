using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CreditsAnim : MonoBehaviour
{
    public GameObject Wrapper;
    public float to;
    public float duration;
    //public Ease easeInOutBack;
    // Start is called before the first frame update
    void Start()
    {
    DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(2200, 10);
    Wrapper.transform.DOMoveY(to, duration,true).SetEase(Ease.Linear);

    }


}
