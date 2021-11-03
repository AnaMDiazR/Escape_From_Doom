using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseController : MonoBehaviour
{
    public Canvas Perdiste;
    private bool corriendo;
    public PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        Perdiste.enabled = false;
    }

    void Update()
    {
        if (player.Vidas == 0)
        {
            Juego_perdido();
        }

    }


    public void Juego_perdido()
    {

        if (corriendo)
        {
            Time.timeScale = 1f;
            Perdiste.enabled = false;
        }
        else
        {
            Time.timeScale = 0f;
            Perdiste.enabled = true;
        }

    }

    public bool esta_perdiendo()
    {
        return corriendo;
    }
}
