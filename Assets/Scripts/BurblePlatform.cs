using UnityEngine;

public class BurblePlatform : MonoBehaviour
{
    public float speed = 0.7f;
    protected virtual void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }
}
