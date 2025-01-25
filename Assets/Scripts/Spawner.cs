using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField]
    private List<GameObject> burblesEasy = new List<GameObject>();
    [SerializeField]
    private List<GameObject> burblesMedium = new List<GameObject>();
    [SerializeField]
    private List<GameObject> burblesHard = new List<GameObject>();

    [Header("Config")]
    [SerializeField]
    private float time = 2f;

    void Start()
    {
        StartCoroutine(SpawnBurble());
    }

    private IEnumerator SpawnBurble()
    {
        yield return new WaitForSeconds(time);

        List<GameObject> burbleList = new List<GameObject>();
        burbleList.AddRange(burblesEasy);
        if (true)//medium
            burbleList.AddRange(burblesMedium);
        if (true)//hard
            burbleList.AddRange(burblesHard);

        var burble = Random.Range(0, burbleList.Count -1);

        GameObject newBurble = Instantiate(burbleList[burble], transform.position, Quaternion.identity);

        StartCoroutine(SpawnBurble());
    }
}
