using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalSystemCreator : MonoBehaviour
{
    public GameObject[] prefabsToPlace; // Lista de prefabs que quieres colocar

    private GameObject currentPrefab; // Prefab seleccionado actualmente

    void Start()
    {
        // Inicializar el prefab actual (puedes cambiar esto dependiendo de tus necesidades)
        if (prefabsToPlace.Length > 0)
            currentPrefab = prefabsToPlace[0];
    }

    // M�todo para cambiar el prefab actual
    public void ChangeCurrentPrefab(int index)
    {
        if (index < prefabsToPlace.Length)
            currentPrefab = prefabsToPlace[index];
    }

    // M�todo para colocar el prefab en la posici�n del rat�n
    public void PlacePrefab()
    {
        if (currentPrefab != null)
        {
            // Obtener la posici�n del rat�n en el mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Asegurarse de que la posici�n Z sea 0 (en el plano 2D)

            // Instanciar el prefab en la posici�n del rat�n
            Instantiate(currentPrefab, mousePosition, Quaternion.identity);
        }
    }

}
