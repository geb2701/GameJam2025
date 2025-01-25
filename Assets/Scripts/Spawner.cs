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

    [Range(1, 10)][SerializeField] private int dificulty = 1;
    private int lastDif = 0;
    private List<GameObject> burbleList = new List<GameObject>();
    void Start()
    {
        StartCoroutine(SpawnBurble());
    }

    private IEnumerator SpawnBurble()
    {
        yield return new WaitForSeconds(time);

        if (dificulty != lastDif)
        {
            ChangeDificult();
        }

        var burble = Random.Range(0, burbleList.Count - 1);

        GameObject newBurble = Instantiate(burbleList[burble], transform.position, Quaternion.identity);
        newBurble.transform.localScale = Vector3.one * 2;
        StartCoroutine(SpawnBurble());
    }

    private void ChangeDificult()
    {
        lastDif = dificulty;
        burbleList = new();
        switch (dificulty)
        {
            case 1:
                burbleList.AddRange(burblesEasy);
                break;
            case 2:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                break;
            case 3:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                break;
            case 4:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                break;
            case 5:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                break;
            case 6:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesHard);
                break;
            case 7:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesHard);
                break;
            case 8:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesHard);
                break;
            case 9:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesHard);
                burbleList.AddRange(burblesHard);
                break;
            default:
                burbleList.AddRange(burblesEasy);
                burbleList.AddRange(burblesMedium);
                burbleList.AddRange(burblesHard);
                burbleList.AddRange(burblesHard);
                burbleList.AddRange(burblesHard);
                break;
        }
    }
}
