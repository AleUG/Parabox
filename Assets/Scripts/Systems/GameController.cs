using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public StarsManager starsManager;
    public List<GameObject> objetosADesbloquear; // Lista de objetos que deseas desbloquear
    public List<GameObject> objetosAparecer; // Lista de objetos que deseas hacer aparecer

    public int starsNecesarias = 10;

    private void Start()
    {
        // Verificar y aplicar el estado guardado de cada objetoAparecer
        for (int i = 0; i < objetosAparecer.Count; i++)
        {
            string key = "objetoAparecerDestroyed_" + i;
            if (PlayerPrefs.GetInt(key, 0) == 1)
            {
                if (objetosAparecer[i] != null)
                {
                    Destroy(objetosAparecer[i]);
                    objetosAparecer[i] = null; // Asegurarse de que se maneje como null en el futuro
                }
            }
        }
    }

    private void Update()
    {
        ActualizarObjetos();
    }

    public void ActualizarObjetos()
    {
        // Verificar si el jugador tiene al menos una cierta cantidad de estrellas para desbloquear los objetos
        bool suficientesEstrellas = starsManager.ObtenerEstrellasConseguidas() >= starsNecesarias;

        for (int i = 0; i < objetosADesbloquear.Count; i++)
        {
            if (objetosADesbloquear[i] != null)
            {
                objetosADesbloquear[i].SetActive(!suficientesEstrellas);
            }
        }

        for (int i = 0; i < objetosAparecer.Count; i++)
        {
            if (objetosAparecer[i] != null)
            {
                objetosAparecer[i].SetActive(suficientesEstrellas);
            }
        }
    }

    public void ActiveObjectAparecer(int index, bool active)
    {
        if (index >= 0 && index < objetosAparecer.Count && objetosAparecer[index] != null)
        {
            objetosAparecer[index].SetActive(active);
        }
    }

    public void DestroyObject(int index)
    {
        if (index >= 0 && index < objetosAparecer.Count && objetosAparecer[index] != null)
        {
            Destroy(objetosAparecer[index]);
            PlayerPrefs.SetInt("objetoAparecerDestroyed_" + index, 1);
            PlayerPrefs.Save();
            objetosAparecer[index] = null; // Asegurarse de que se maneje como null en el futuro
        }
    }

    public void DeleteDataObjects()
    {
        for (int i = 0; i < objetosAparecer.Count; i++)
        {
            string key = "objetoAparecerDestroyed_" + i;
            PlayerPrefs.DeleteKey(key);
        }
        PlayerPrefs.Save();
    }
}
