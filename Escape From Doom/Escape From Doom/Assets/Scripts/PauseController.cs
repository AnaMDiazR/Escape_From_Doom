using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    
    private bool Juego_corriendo;
     public Canvas Pausa;

    void Start()
    {
        Pausa.enabled = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Juego_cambiando_de_estado();

        }
    }
   

    public void Juego_cambiando_de_estado()
    {

        Juego_corriendo = !Juego_corriendo;
        if (Juego_corriendo)
        {
            Time.timeScale = 1f;
            Pausa.enabled = false;
        }
        else
        {
            Time.timeScale = 0f;
            Pausa.enabled = true;
        }

    }


    public bool esta_corriendo()
    {
        return Juego_corriendo;
    }

}
