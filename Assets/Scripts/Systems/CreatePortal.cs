using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreatePortal : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs
    private GameObject currentPortal;

    private bool isDragging = false;

    public int limitePortales = 2;
    private bool onLimit = false;
    private int cantidadPortales = 0;

    public string animBlocked;

    public UnityEvent onPortalCreate;

    public void OnButtonClick(int index)
    {
        if (onLimit)
        {
            return;
        }
        else
        {
            if (currentPortal == null)
            {
                if (index < 0 || index >= prefabs.Length)
                {
                    Debug.LogWarning("Índice de prefab fuera de rango");
                    return;
                }

                cantidadPortales++;

                // Instancia el prefab seleccionado en la posición del cursor
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // Asegúrate de que el z sea 0 para un juego 2D
                currentPortal = Instantiate(prefabs[index], mousePosition, Quaternion.identity);
                isDragging = true;
                

                // Desactiva el script DragNDrop mientras se está arrastrando
                DragNDrop dragNDrop = currentPortal.GetComponent<DragNDrop>();
                if (dragNDrop != null)
                {
                    dragNDrop.enabled = false;
                    dragNDrop.canEffect = false;
                }

                
            }
        }
    }

    void Update()
    {
        PortalesActuales(limitePortales);

        // Si el portal está siendo arrastrado, sigue al cursor del mouse
        if (isDragging && currentPortal != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Asegúrate de que el z sea 0 para un juego 2D
            currentPortal.transform.position = mousePosition;

            // Si se hace clic de nuevo, deja de arrastrar el portal
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = false;

                // Reactiva el script DragNDrop después de soltar el portal
                DragNDrop dragNDrop = currentPortal.GetComponent<DragNDrop>();
                Animator animator = currentPortal.GetComponent<Animator>();

                if (dragNDrop != null)
                {
                    dragNDrop.enabled = true;
                    dragNDrop.canEffect = true;

                    animator.Play("colocar");

                    onPortalCreate.Invoke();
                }

                currentPortal = null; // Libera la referencia al portal actual
            }
        }
    }

    public void PortalesActuales(int limite)
    {
        if (cantidadPortales >= limite)
        {
            onLimit = true;
        }
        else
        {
            onLimit = false;
        }
    }

    public void RestarPortales()
    {
        cantidadPortales--;
    }

    public void BlockPortal(Animator animator)
    {
        if (onLimit)
        {
            animator.Play(animBlocked);
        }
    }
}
