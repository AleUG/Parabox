using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsManager : MonoBehaviour
{
    // Diccionario para registrar estrellas por nivel
    private Dictionary<int, int> estrellasPorNivel = new Dictionary<int, int>();

    public TextMeshProUGUI textStars;

    void Start()
    {
        // Cargar el registro de estrellas por nivel desde PlayerPrefs
        CargarRegistroEstrellasPorNivel();
        // Actualizar el texto al inicio
        ActualizarTextoEstrellas();
    }

    public void AgregarEstrella(int nivel)
    {
        // Verificar si el nivel ya tiene 3 estrellas
        if (ObtenerEstrellasNivel(nivel) < 3)
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
            textStars.text = "x" + ObtenerEstrellasConseguidas().ToString();
        }
    }

    private void CargarRegistroEstrellasPorNivel()
    {
        // Cargar el registro de estrellas por nivel desde PlayerPrefs
        for (int i = 1; i <= 10; i++) // Supongamos que hay 10 niveles (ajusta según tu juego)
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
}
