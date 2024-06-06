using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public RectTransform levelsContainer; // Contenedor de los niveles
    public float scrollAmount = 300f; // Cantidad de desplazamiento
    public float minScrollX = -1000f; // Límite mínimo de desplazamiento en X
    public float maxScrollX = 1000f; // Límite máximo de desplazamiento en X
    public Button leftButton; // Botón de desplazamiento hacia la izquierda
    public Button rightButton; // Botón de desplazamiento hacia la derecha

    private void Start()
    {
        // Asignar métodos a los eventos de los botones
        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);
    }

    private void ScrollLeft()
    {
        // Calcular la nueva posición del contenedor
        float newX = levelsContainer.anchoredPosition.x + scrollAmount;
        // Limitar el desplazamiento a la izquierda
        newX = Mathf.Clamp(newX, minScrollX, maxScrollX);
        // Desplazar el contenedor hacia la izquierda
        levelsContainer.anchoredPosition = new Vector2(newX, levelsContainer.anchoredPosition.y);
    }

    private void ScrollRight()
    {
        // Calcular la nueva posición del contenedor
        float newX = levelsContainer.anchoredPosition.x - scrollAmount;
        // Limitar el desplazamiento a la derecha
        newX = Mathf.Clamp(newX, minScrollX, maxScrollX);
        // Desplazar el contenedor hacia la derecha
        levelsContainer.anchoredPosition = new Vector2(newX, levelsContainer.anchoredPosition.y);
    }

    private void OnDrawGizmos()
    {
        // Dibujar una línea para representar la distancia entre los límites mínimo y máximo del desplazamiento en el eje X
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minScrollX, levelsContainer.position.y, 0f), new Vector3(maxScrollX, levelsContainer.position.y, 0f));
    }
}
