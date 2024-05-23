using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Image barra;

    public float duracionTotal = 10f; // Duración total de la barra en segundos
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = duracionTotal;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            // Aquí puedes realizar acciones adicionales cuando la barra se haya vaciado completamente
        }

        ActualizarBarra(tiempoRestante / duracionTotal);
    }

    void ActualizarBarra(float porcentaje)
    {
        barra.fillAmount = porcentaje;
    }
}
