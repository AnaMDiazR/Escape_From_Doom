using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public Canvas Ganaste;
    private bool corriendo_juego;

    // Start is called before the first frame update
    void Start()
    {
        Ganaste.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag.Equals("Player"))
        {
            Juego_ganado();
        }
    }

    public void Juego_ganado()
    {

        corriendo_juego = !corriendo_juego;
        if (corriendo_juego)
        {
            Time.timeScale = 1f;
            Ganaste.enabled = false;
        }
        else
        {
            Time.timeScale = 0f;
            Ganaste.enabled = true;
        }

    }

    public bool esta_ganado()
    {
        return corriendo_juego;
    }
    

}
