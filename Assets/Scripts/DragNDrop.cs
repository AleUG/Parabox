using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Aseg�rate de que la posici�n Z sea 0 para objetos 2D

            // Verifica si el clic se hizo sobre el objeto
            if (col.OverlapPoint(mousePosition))
            {
                isDragging = !isDragging;  // Alterna el estado de arrastre
                if (isDragging)
                {
                    // Calcula el offset entre la posici�n del objeto y la del mouse
                    offset = transform.position - mousePosition;
                }
            }
        }

        if (isDragging)
        {
            // Mueve el objeto a la posici�n del mouse m�s el offset
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Aseg�rate de que la posici�n Z sea 0 para objetos 2D
            transform.position = mousePosition + offset;
        }
    }
}
