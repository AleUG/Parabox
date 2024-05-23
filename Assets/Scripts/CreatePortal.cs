using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    // Referencia al prefab que se va a instanciar
    public GameObject prefab;

    // Referencia al portal instanciado
    private GameObject currentPortal;

    // Indica si se est� arrastrando el portal
    private bool isDragging = false;

    // Funci�n que se llama cuando se presiona el bot�n
    public void OnButtonClick()
    {
        if (currentPortal == null)
        {
            // Instancia el prefab en la posici�n del cursor
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Aseg�rate de que el z sea 0 para un juego 2D
            currentPortal = Instantiate(prefab, mousePosition, Quaternion.identity);
            isDragging = true;
        }
    }

    void Update()
    {
        // Si el portal est� siendo arrastrado, sigue al cursor del mouse
        if (isDragging && currentPortal != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Aseg�rate de que el z sea 0 para un juego 2D
            currentPortal.transform.position = mousePosition;

            // Si se hace clic de nuevo, deja de arrastrar el portal
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = false;
            }
        }
    }
}
