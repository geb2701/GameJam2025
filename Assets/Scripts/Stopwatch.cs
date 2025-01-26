using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private Text timerText; // Referencia al Text de UI donde mostrar el tiempo
    [SerializeField] private Spawner spawner; // Referencia al Text de UI donde mostrar el tiempo
    private float timeElapsed = 0f;
    private int lastDif = -1;


    void Update()
    {
        timeElapsed += Time.deltaTime;
        //timerText.text = Mathf.FloorToInt(timeElapsed).ToString();
        Debug.Log(Mathf.FloorToInt(timeElapsed));
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
