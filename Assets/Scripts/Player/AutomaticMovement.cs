using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public float speed;
    private bool isMovingRight = true;


    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (!isMovingRight)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    public void ChangeDirection()
    {
        if(isMovingRight)
        {
            isMovingRight = false;
        }
        else if(!isMovingRight)
        {
            isMovingRight = true;
        }
    }
}
