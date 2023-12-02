using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambiarescenaconTitulo : MonoBehaviour
{  
    public void CargarEscena(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena);
        Time.timeScale = 1f;
    }

}