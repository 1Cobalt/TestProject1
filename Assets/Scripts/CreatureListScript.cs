using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreatureListScript : MonoBehaviour
{
    public int enemiesCount = 11;
    public int cleanerCount = 7;
    public int allyCount = 0;

    public GameObject winText; 

    void Start()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Enemies: " + enemiesCount + "\n Cleaners: " + cleanerCount + "\n Allies: " + allyCount;
    }

    public void ChangeEnemiesCount(int changeCount)
    {
        enemiesCount = enemiesCount + changeCount;
        allyCount = allyCount - changeCount;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Enemies: " + enemiesCount + "\n Cleaners: " + cleanerCount + "\n Allies: " + allyCount;

        if (enemiesCount == 0 && cleanerCount == 0)
        {
            Time.timeScale = 0;
            winText.SetActive(true);
        }
    }
    public void ChangeCleanerCount(int changeCount)
    {
        cleanerCount = cleanerCount + changeCount;
        allyCount = allyCount - changeCount;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Enemies: " + enemiesCount + "\n Cleaners: " + cleanerCount + "\n Allies: " + allyCount;
        if (enemiesCount == 0 && cleanerCount == 0)
        {
            Time.timeScale = 0;
            winText.SetActive(true);
        }
    }
}
