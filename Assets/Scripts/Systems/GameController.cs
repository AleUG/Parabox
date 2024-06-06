using UnityEngine;

public class GameController : MonoBehaviour
{
    public StarsManager starsManager;
    public GameObject objetoADesbloquear; // El objeto que deseas desbloquear

    public int starsNecesarias = 10;


    private void Update()
    {
        // Verificar si el jugador tiene al menos una cierta cantidad de estrellas para desbloquear el objeto
        if (starsManager.ObtenerEstrellasConseguidas() >= starsNecesarias) // Cambia 10 por la cantidad necesaria de estrellas
        {
            objetoADesbloquear.SetActive(false);
        }
        else
        {
            objetoADesbloquear.SetActive(true);
        }
    }



}
