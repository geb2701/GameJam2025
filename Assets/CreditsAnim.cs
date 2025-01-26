using DG.Tweening;
using UnityEngine;
public class CreditsAnim : MonoBehaviour
{
    public GameObject Wrapper;
    public float to;
    public float duration;
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(2200, 10);
        Wrapper.transform.DOMoveY(to, duration).SetEase(Ease.InOutQuad);

    }


}
