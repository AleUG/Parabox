using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
    public RectTransform levelsContainer; // Contenedor de los niveles
    public float scrollAmount = 300f; // Cantidad de desplazamiento
    public float minScrollX = -1000f; // L�mite m�nimo de desplazamiento en X
    public float maxScrollX = 1000f; // L�mite m�ximo de desplazamiento en X
    public Button leftButton; // Bot�n de desplazamiento hacia la izquierda
    public Button rightButton; // Bot�n de desplazamiento hacia la derecha
    public float scrollDuration = 0.5f; // Duraci�n del desplazamiento suave

    private Coroutine currentCoroutine;

    private void Start()
    {
        // Asignar m�todos a los eventos de los botones
        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);
    }

    private void ScrollLeft()
    {
        // Calcular la nueva posici�n del contenedor
        float targetX = levelsContainer.anchoredPosition.x + scrollAmount;
        // Limitar el desplazamiento a la izquierda
        targetX = Mathf.Clamp(targetX, minScrollX, maxScrollX);
        // Iniciar la corutina para desplazamiento suave
        StartSmoothScroll(targetX);
    }

    private void ScrollRight()
    {
        // Calcular la nueva posici�n del contenedor
        float targetX = levelsContainer.anchoredPosition.x - scrollAmount;
        // Limitar el desplazamiento a la derecha
        targetX = Mathf.Clamp(targetX, minScrollX, maxScrollX);
        // Iniciar la corutina para desplazamiento suave
        StartSmoothScroll(targetX);
    }

    private void StartSmoothScroll(float targetX)
    {
        // Detener la corutina actual si ya hay una corriendo
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        // Iniciar una nueva corutina
        currentCoroutine = StartCoroutine(SmoothScroll(targetX));
    }

    private IEnumerator SmoothScroll(float targetX)
    {
        Vector2 startPos = levelsContainer.anchoredPosition;
        Vector2 endPos = new Vector2(targetX, levelsContainer.anchoredPosition.y);
        float elapsedTime = 0f;

        while (elapsedTime < scrollDuration)
        {
            levelsContainer.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / scrollDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el contenedor llegue a la posici�n final exacta
        levelsContainer.anchoredPosition = endPos;
    }

    private void OnDrawGizmos()
    {
        // Dibujar una l�nea para representar la distancia entre los l�mites m�nimo y m�ximo del desplazamiento en el eje X
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minScrollX, levelsContainer.position.y, 0f), new Vector3(maxScrollX, levelsContainer.position.y, 0f));
    }
}
