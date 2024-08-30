using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float movementSpeedX = 0.7f;
    public float movementSpeedY = 0.7f;
    
    private float speedHorizontal;
    private float speedVertical;

    public float changeMoveTimeMin = 2.0f;
    public float changeMoveTimeMax = 6.0f;

    private float rand;

    void Start()
    {
        rand = Random.Range(changeMoveTimeMin, changeMoveTimeMax);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HorizontalWall")
        {
            movementSpeedY = movementSpeedY * -1f;
        }
        if (other.gameObject.tag == "VerticalWall")
        {
            movementSpeedX = movementSpeedX * -1f;
        }
    }

    void ChangeMoveSpeed()
    {
        rand = Random.Range(0.0f, 12.0f);
        if (rand <= 5.0f)
        {
            movementSpeedX = Random.Range(6.0f, 10.0f);
            movementSpeedY = Random.Range(6.0f, 10.0f);

            if ((movementSpeedX % 2) == 0)
            {
                movementSpeedX = -movementSpeedX;
            }
            if ((movementSpeedY % 2) == 0)
            {
                movementSpeedY = -movementSpeedY;
            }

        }
        else if (rand <= 7.0f)
        {
            movementSpeedX = -movementSpeedX;
        }
        else if (rand <= 9.0f)
        {
            movementSpeedY = -movementSpeedY;
        }
        else if (rand <= 12.0f)
        {
            movementSpeedX = -movementSpeedX;
            movementSpeedY = -movementSpeedY;
        }

        rand = Random.Range(changeMoveTimeMin, changeMoveTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
      

        speedHorizontal = movementSpeedX * Time.deltaTime;
        speedVertical = movementSpeedY * Time.deltaTime;

        transform.Translate(speedHorizontal, 0, speedVertical);

        rand -= Time.deltaTime;
        if (rand <= 0)
        {
            ChangeMoveSpeed();
        }
    }
}
