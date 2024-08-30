using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrashScript : MonoBehaviour
{
    public GameObject CreatureList;
    public AudioSource paintSound;
    public GameObject paintParticle;

   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ally" && this.gameObject.tag == "Cleaner")
        {
            Renderer enemyRenderer = other.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = Color.white;
                other.gameObject.tag = "Enemy";
            }

            CreatureList.GetComponent<CreatureListScript>().ChangeEnemiesCount(1);
            paintSound.Play();
            Instantiate(paintParticle, transform.position, Quaternion.identity);
        }

        else if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Ally")
        {
            Renderer enemyRenderer = other.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = GetComponent<Renderer>().material.color;
                other.gameObject.tag = "Ally";
            }

            CreatureList.GetComponent<CreatureListScript>().ChangeEnemiesCount(-1);
            paintSound.Play();
            Instantiate(paintParticle, transform.position, Quaternion.identity);
        }
    }

}
