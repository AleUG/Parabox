using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStarsDisplay : MonoBehaviour
{
    // Referencia al StarsManager
    public StarsManager starsManager;

    // Lista de contenedores de estrellas por nivel
    public List<LevelStars> levelStarsList;

    [System.Serializable]
    public class LevelStars
    {
        public Image star1;
        public Image star2;
        public Image star3;
    }

    private void Start()
    {
        // Asegúrate de que la cantidad de elementos en levelStarsList coincida con el número de niveles
        if (levelStarsList.Count != 10) // Supongamos que hay 10 niveles
        {
            Debug.LogError("La cantidad de elementos en levelStarsList no coincide con la cantidad de niveles.");
            return;
        }

        // Actualizar las imágenes de estrellas para cada nivel al inicio
        ActualizarImagenesEstrellasNiveles();
    }

    public void ActualizarImagenesEstrellasNiveles()
    {
        for (int i = 0; i < levelStarsList.Count; i++)
        {
            int nivel = i + 1; // Los niveles comienzan en 1
            int estrellas = starsManager.ObtenerEstrellasNivel(nivel);

            // Activar o desactivar las imágenes de estrellas según la cantidad de estrellas conseguidas
            levelStarsList[i].star1.enabled = estrellas >= 1;
            levelStarsList[i].star2.enabled = estrellas >= 2;
            levelStarsList[i].star3.enabled = estrellas >= 3;
        }
    }
}
