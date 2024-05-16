using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Vector3 offset;
    bool agarrado;
    private void OnMouseDown()
    {
        Vector3 mp = Input.mousePosition;
        mp.z = Camera.main.transform.position.z;

        Vector3 wmp = Camera.main.ScreenToWorldPoint(mp);
        offset = transform.position - wmp;
        agarrado = true;
    }

    private void OnMouseDrag()
    {
        if(agarrado)
        {
            Vector3 mp = Input.mousePosition;
            mp.z = Camera.main.transform.position.z;

            Vector3 wmp = Camera.main.ScreenToWorldPoint(mp);
            transform.position = wmp + offset;
        }

    }

    private void OnMouseUp()
    {
        agarrado = false;
    }
}
