using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public PlayerController personaje;
    public GameObject centenas, decenas, unidades;
    private Animator ce, de, un;
    private string[] estados = { "Estado_00", "Estado_01", "Estado_02", "Estado_03", "Estado_04", "Estado_05", "Estado_06", "Estado_07", "Estado_08", "Estado_09" };

    // Start is called before the first frame update
    void Start()
    {
        ce = centenas.GetComponent<Animator>();
        de = decenas.GetComponent<Animator>();
        un = unidades.GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
       ActualizarContador(personaje.Puntos);
    }

    public void ActualizarContador(int numero)
    {
        int unidades = numero % 10;
        int decenas = numero % 100 - unidades;
        int centenas = numero % 1000 - decenas;

        Debug.Log("numero"+numero+"centenas"+centenas/100 + "decenas" + decenas/10 + "unidades" + unidades);

        decenas = decenas / 10;
        centenas = centenas / 100;

        if (numero>9)
        {
            //Hay decenas
            de.Play(estados[decenas]);
        }
        else
        {
            de.Play(estados[0]);
        }

        if (numero > 99)
        {
            //Hay centenas
            ce.Play(estados[centenas]);
        }
        else
        {
            ce.Play(estados[0]);
        }

        un.Play(estados[unidades]);
    }
}
