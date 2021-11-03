using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Controller : MonoBehaviour
{
    public GameObject proyectil; 
    public Transform Posicion_proyectil;
    public Transform Caida;
    public float velocidad;
    
    void Update()
    {
        float parar = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,Caida.position,parar);

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag.Equals("Limite") || Other.gameObject.tag.Equals("Player"))
        {

            this.transform.position = new Vector3(Posicion_proyectil.position.x, Posicion_proyectil.position.y, 0);//si toca el limite vuelve a la psocion
        }
    }
}
