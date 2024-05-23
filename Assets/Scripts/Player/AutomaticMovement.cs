using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public float speed;
    private bool isMovingRight = true;
    private bool isMoving = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving)
        {
            isMoving = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true; 
        }

        if (isMoving)
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

    private void StopMoving()
    {

    }
}
