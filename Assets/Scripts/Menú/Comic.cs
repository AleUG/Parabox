using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Comic : MonoBehaviour
{
    public GameObject[] vi�etasComic;  // Array de vi�etas del c�mic
    public float fadeDuration = 1.0f;  // Duraci�n del efecto de desvanecimiento
    private int currentIndex = 0;  // �ndice de la vi�eta actual
    private bool comicEnded = false;  // Bandera para indicar si el c�mic ha terminado

    public UnityEvent onEndComic;

    // Start is called before the first frame update
    void Start()
    {
        // Desactivar todas las vi�etas al inicio
        for (int i = 0; i < vi�etasComic.Length; i++)
        {
            vi�etasComic[i].SetActive(false);
        }

        // Activar la primera vi�eta
        if (vi�etasComic.Length > 0)
        {
            vi�etasComic[0].SetActive(true);
            StartCoroutine(FadeIn(vi�etasComic[0]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (comicEnded)
        {
            return;
        }

        // Avanzar a la siguiente vi�eta
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextPanel();
        }
    }

    void ShowNextPanel()
    {
        // Incrementar el �ndice
        currentIndex++;

        // Verificar si hemos llegado a la �ltima vi�eta
        if (currentIndex >= vi�etasComic.Length)
        {
            EndComic();
            return;
        }

        // Activar la siguiente vi�eta
        vi�etasComic[currentIndex].SetActive(true);
        StartCoroutine(FadeIn(vi�etasComic[currentIndex]));
    }

    public void EndComic()
    {
        comicEnded = true;
        onEndComic.Invoke();
    }

    IEnumerator FadeIn(GameObject vi�eta)
    {
        SpriteRenderer sr = vi�eta.GetComponent<SpriteRenderer>();
        Color color = sr.color;
        color.a = 0;
        sr.color = color;

        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime / fadeDuration;
            sr.color = color;
            yield return null;
        }

        color.a = 1.0f;
        sr.color = color;
    }
}
