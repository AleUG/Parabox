using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsManager : MonoBehaviour
{
    // Diccionario para registrar estrellas por nivel
    private Dictionary<int, int> estrellasPorNivel = new Dictionary<int, int>();

    public TextMeshProUGUI textStars;

    private void Update()
    {
        ActualizarTextoEstrellas();
    }

    void Awake()
    {
        // Cargar el registro de estrellas por nivel desde PlayerPrefs
        CargarRegistroEstrellasPorNivel();
        // Actualizar el texto al inicio
        ActualizarTextoEstrellas();
    }

    public void AgregarEstrella(int nivel)
    {
        // Verificar si el nivel ya tiene 3 estrellas
        if (!estrellasPorNivel.ContainsKey(nivel))
        {
            // Si el nivel no est� en el diccionario, inicializar con 0 estrellas
            estrellasPorNivel[nivel] = 0;
        }

        if (estrellasPorNivel[nivel] < 3)
        {
            // Incrementar las estrellas del nivel
            estrellasPorNivel[nivel]++;

            // Guardar el registro actualizado en PlayerPrefs
            GuardarRegistroEstrellasPorNivel();
            // Actualizar el texto
            ActualizarTextoEstrellas();
        }
    }

    public int ObtenerEstrellasConseguidas()
    {
        int totalEstrellas = 0;
        foreach (int estrellas in estrellasPorNivel.Values)
        {
            totalEstrellas += estrellas;
        }
        return totalEstrellas;
    }

    private void ActualizarTextoEstrellas()
    {
        if (textStars != null)
        {
            textStars.text = "" + ObtenerEstrellasConseguidas().ToString();
        }
    }

    private void CargarRegistroEstrellasPorNivel()
    {
        // Cargar el registro de estrellas por nivel desde PlayerPrefs
        for (int i = 1; i <= 10; i++) // Supongamos que hay 10 niveles (ajusta seg�n tu juego)
        {
            int estrellas = PlayerPrefs.GetInt("EstrellasNivel" + i, 0);
            estrellasPorNivel[i] = estrellas;
        }
    }

    private void GuardarRegistroEstrellasPorNivel()
    {
        // Guardar el registro de estrellas por nivel en PlayerPrefs
        foreach (var kvp in estrellasPorNivel)
        {
            PlayerPrefs.SetInt("EstrellasNivel" + kvp.Key, kvp.Value);
        }
        PlayerPrefs.Save();
    }

    public int ObtenerEstrellasNivel(int nivel)
    {
        if (estrellasPorNivel.ContainsKey(nivel))
        {
            return estrellasPorNivel[nivel];
        }
        return 0;
    }

    public void DeleteData()
    {
        // Borrar el registro de estrellas por nivel en PlayerPrefs
        for (int i = 1; i <= 10; i++) // Suponiendo que hay 10 niveles (ajusta seg�n tu juego)
        {
            PlayerPrefs.DeleteKey("EstrellasNivel" + i);
        }
        PlayerPrefs.Save();

        // Reiniciar el diccionario de estrellas por nivel
        estrellasPorNivel.Clear();

        // Actualizar el texto de estrellas
        ActualizarTextoEstrellas();
    }
}
