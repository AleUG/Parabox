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
    private GameObject[] portalesCantidad;

    public UnityEvent onPortalCreate;

    private void Awake()
    {
        // Inicializar el array portalesCantidad
        portalesCantidad = new GameObject[2];
        portalesCantidad[0] = GameObject.Find("portal1_full");
        portalesCantidad[1] = GameObject.Find("portal2_full");

        // Desactivar todos los portales inicialmente
        foreach (var portal in portalesCantidad)
        {
            if (portal != null)
            {
                portal.SetActive(false);
            }
        }
    }

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
                    Debug.LogWarning("�ndice de prefab fuera de rango");
                    return;
                }

                cantidadPortales++;
                UpdatePortalesCantidad(); // Actualizar el estado de los portales

                // Instancia el prefab seleccionado en la posici�n del cursor
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // Aseg�rate de que el z sea 0 para un juego 2D
                currentPortal = Instantiate(prefabs[index], mousePosition, Quaternion.identity);
                isDragging = true;


                // Desactiva el script DragNDrop mientras se est� arrastrando
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

                // Reactiva el script DragNDrop despu�s de soltar el portal
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
        onLimit = cantidadPortales >= limite;
    }

    public void RestarPortales()
    {
        cantidadPortales--;
        UpdatePortalesCantidad(); // Actualizar el estado de los portales
    }

    private void UpdatePortalesCantidad()
    {
        // Actualizar el estado de los portales en el array portalesCantidad
        for (int i = 0; i < portalesCantidad.Length; i++)
        {
            if (portalesCantidad[i] != null)
            {
                portalesCantidad[i].SetActive(i < cantidadPortales);
            }
        }
    }

    public void BlockPortal(Animator animator)
    {
        if (onLimit)
        {
            animator.Play(animBlocked);
        }
    }
}
