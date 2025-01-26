using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float amplitudeX = 5f;
    [SerializeField] private float amplitudeY = 2f;

    private float time;

    private Vector3 initialPosition;

    void Start()
    {
        // Guardamos la posición inicial
        initialPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime * speed;

        float x = Mathf.Sin(time) * amplitudeX;
        float y = Mathf.Sin(2 * time) * amplitudeY;

        transform.position = initialPosition + new Vector3(x, y, 0f);
    }
}
