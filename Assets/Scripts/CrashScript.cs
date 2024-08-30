using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{
    
    private Color playerColor;
    public GameObject CreatureList;
    public AudioSource paintSound;
    public GameObject paintParticle;


    void Start()
    {
        Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerColor = playerRenderer.material.color;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Renderer enemyRenderer = other.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = playerColor;
                other.gameObject.tag = "Ally";
            }
            CreatureList.GetComponent<CreatureListScript>().ChangeEnemiesCount(-1);
            paintSound.Play();
            Instantiate(paintParticle, transform.position, Quaternion.identity);
        }
        else if (other.gameObject.tag == "Cleaner")
        {
            Renderer enemyRenderer = other.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = playerColor;
                other.gameObject.tag = "Ally";
            }

            CreatureList.GetComponent<CreatureListScript>().ChangeCleanerCount(-1);
            paintSound.Play();
            Instantiate(paintParticle, transform.position, Quaternion.identity);
        }
    }
}
