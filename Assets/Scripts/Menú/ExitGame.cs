using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public float timeDelayExit;
    public void Cerrar()
    {
        Debug.Log("Saliendo del juego");
        StartCoroutine(DelayExit(timeDelayExit));
    }

    private IEnumerator DelayExit(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit(); // Cierra la aplicación

        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

}