using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionSystemCol : MonoBehaviour
{
    public UnityEvent onEnter, onStay, onExit;
    public string tagObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagObject))
        {
            onEnter.Invoke();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagObject))
        {
            onStay.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagObject))
        {
            onExit.Invoke();
        }
    }
}
