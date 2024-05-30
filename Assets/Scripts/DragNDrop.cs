using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;
    private float lastDragTime;
    private float cooldown = 0.25f;

    public bool canEffect = true;

    private Collider2D col;
    private Animator animator;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        animator = GetComponentInParent<Animator>();
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastDragTime >= cooldown)
        {
            lastDragTime = Time.time;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Asegúrate de que la posición Z sea 0 para objetos 2D

            // Verifica si el clic se hizo sobre el objeto
            if (col.OverlapPoint(mousePosition))
            {
                isDragging = !isDragging;  // Alterna el estado de arrastre
                if (isDragging)
                {
                    animator.Play("agarrar");
                    canEffect = false;
                    // Calcula el offset entre la posición del objeto y la del mouse
                    offset = transform.position - mousePosition;
                }
                else
                {
                    canEffect = true;
                    animator.Play("colocar");
                }
            }
        }

        if (isDragging)
        {
            // Mueve el objeto a la posición del mouse más el offset
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // Asegúrate de que la posición Z sea 0 para objetos 2D
            transform.position = mousePosition + offset;
        }
    }
}
