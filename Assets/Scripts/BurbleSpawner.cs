using System.Collections;
using UnityEngine;

public class BurbleSpawner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField]
    private GameObject burble;

    [Header("Config")]

    [SerializeField]
    private float timeMin = 1;
    [SerializeField]
    private float timeMax = 3.5f;
    [SerializeField]
    private float range = 5f;

    [Header("Burble Speed")]
    [SerializeField]
    private float minSpeed = 0.5f;
    [SerializeField]
    private float maxSpeed = 1.5f;

    [SerializeField]
    private float minScale = 0.7f;
    [SerializeField]
    private float maxScale = 1.5f;
    void Start()
    {
        if (timeMax < timeMin)
            timeMax = timeMin;
        StartCoroutine(SpawnBurble());
    }

    private IEnumerator SpawnBurble()
    {
        yield return new WaitForSeconds(RandomInterval());
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-range, range),
            transform.position.y,
            transform.position.z
        );

        GameObject newBurble = Instantiate(burble, spawnPosition, Quaternion.identity);
        Burble burbleScript = newBurble.GetComponent<Burble>();
        if (burbleScript != null)
        {
            burbleScript.speed = Random.Range(minSpeed, maxSpeed);
        }

        Transform burbleTransform = newBurble.transform;

        var scale = Random.Range(minScale, maxScale);
        burbleTransform.localScale = new Vector3(scale, scale, scale);


        StartCoroutine(SpawnBurble());
    }

    private float RandomInterval()
    {
        return Random.Range(timeMin, timeMax);
    }
}
