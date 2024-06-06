using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Image barra;
    public GameObject[] stars;
    public GameObject[] starsWin;

    public float duracionTotal = 10f; // Duración total de la barra en segundos
    private float tiempoRestante;
    private bool estrella1Quitada = false;
    private bool estrella2Quitada = false;

    private StarsManager starsManager;
    public int nivelActual = 1; // Nivel actual del jugador, configurable desde el Inspector o por otro script
    private bool tiempoDetenido = false; // Bandera para controlar si el tiempo está detenido

    void Start()
    {
        tiempoRestante = duracionTotal;
        starsManager = FindObjectOfType<StarsManager>(); // Encuentra el script StarsManager en la escena
    }

    void Update()
    {
        if (!tiempoDetenido)
        {
            tiempoRestante -= Time.deltaTime;

            // Quitar la primera estrella al 75% del tiempo
            if (!estrella1Quitada && tiempoRestante <= duracionTotal * 0.75f)
            {
                stars[0].SetActive(false);
                starsWin[0].SetActive(false);
                estrella1Quitada = true;
            }

            // Quitar la segunda estrella al 50% del tiempo
            if (!estrella2Quitada && tiempoRestante <= duracionTotal * 0.5f)
            {
                stars[1].SetActive(false);
                starsWin[1].SetActive(false);
                estrella2Quitada = true;
            }

            // Quitar la tercera estrella al 0% del tiempo (cuando el tiempo se acaba)
            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                stars[2].SetActive(false);
                starsWin[2].SetActive(false);
            }

            ActualizarBarra(tiempoRestante / duracionTotal);
        }
    }

    void ActualizarBarra(float porcentaje)
    {
        if (barra != null)
        {
            barra.fillAmount = porcentaje;
        }
    }

    public void DetenerTiempoYRegistrarEstrellas()
    {
        if (!tiempoDetenido)
        {
            tiempoDetenido = true; // Marcar que el tiempo está detenido

            // Registra cuántas estrellas ha conseguido el jugador
            int estrellasConseguidas = 0;
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i].activeSelf)
                {
                    estrellasConseguidas++;
                }
            }

            // Registra las estrellas conseguidas en StarsManager
            for (int i = 0; i < estrellasConseguidas; i++)
            {
                starsManager.AgregarEstrella(nivelActual);
            }

            print("Estrellas conseguidas: " + estrellasConseguidas);
        }
    }
}
