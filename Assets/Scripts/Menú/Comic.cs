using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Comic : MonoBehaviour
{
    public GameObject[] viñetasComic;  // Array de viñetas del cómic
    public float fadeDuration = 1.0f;  // Duración del efecto de desvanecimiento
    private int currentIndex = 0;  // Índice de la viñeta actual
    private bool comicEnded = false;  // Bandera para indicar si el cómic ha terminado

    public UnityEvent onEndComic;

    // Start is called before the first frame update
    void Start()
    {
        // Desactivar todas las viñetas al inicio
        for (int i = 0; i < viñetasComic.Length; i++)
        {
            viñetasComic[i].SetActive(false);
        }

        // Activar la primera viñeta
        if (viñetasComic.Length > 0)
        {
            viñetasComic[0].SetActive(true);
            StartCoroutine(FadeIn(viñetasComic[0]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (comicEnded)
        {
            return;
        }

        // Avanzar a la siguiente viñeta
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextPanel();
        }
    }

    void ShowNextPanel()
    {
        // Incrementar el índice
        currentIndex++;

        // Verificar si hemos llegado a la última viñeta
        if (currentIndex >= viñetasComic.Length)
        {
            EndComic();
            return;
        }

        // Activar la siguiente viñeta
        viñetasComic[currentIndex].SetActive(true);
        StartCoroutine(FadeIn(viñetasComic[currentIndex]));
    }

    public void EndComic()
    {
        comicEnded = true;
        onEndComic.Invoke();
    }

    IEnumerator FadeIn(GameObject viñeta)
    {
        SpriteRenderer sr = viñeta.GetComponent<SpriteRenderer>();
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
