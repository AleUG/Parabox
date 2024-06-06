using UnityEngine;

public class GameController : MonoBehaviour
{
    public Contador contador;

    void Start()
    {
        if (contador == null)
        {
            Debug.LogError("Contador no está asignado en el GameController");
            return;
        }

        // Establecer el nivel actual, por ejemplo, al nivel 1
        contador.nivelActual = 1;

        // Simular que el jugador ha completado el nivel y registrar las estrellas conseguidas
        // Llamar a esta función en el momento adecuado, por ejemplo, al finalizar el nivel
        contador.DetenerTiempoYRegistrarEstrellas();
    }
}
