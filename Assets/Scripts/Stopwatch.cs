using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Spawner spawner;
    private float timeElapsed = 0f;


    void Update()
    {
        timeElapsed += Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timeElapsed).ToString();
        ChangeDificult(Mathf.FloorToInt(timeElapsed));
    }

    void ChangeDificult(int time)
    {
        if (spawner != null)
        {
            var level = time / 10;
            if (level == 0)
            {
                level = 1;
            }
            else if (level > 10)
            {
                level = 10;
            }
            spawner.dificulty = level;
        }
    }
}
