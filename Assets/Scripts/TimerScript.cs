using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float currentTime;
    public static TimerScript Instance;
    void Start()
    {
        currentTime = 0;

        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров TimerScript!");
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        this.GetComponent<TMPro.TextMeshProUGUI>().text = (int)(currentTime / 60) + ":" + (currentTime % 60 >= 10 ? (int)(currentTime % 60) : "0" + (int)(currentTime % 60));
    }

    public float GetTime()
    {
        return currentTime;
    }
}
