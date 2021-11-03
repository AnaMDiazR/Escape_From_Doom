using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata_controller : MonoBehaviour
{
    public float velocidad;
    public float radio_busqueda;
    private Rigidbody2D rb;
    public  GameObject rata;
    GameObject Player;
    public Transform posicion_inicial;
    public Transform posicion_final;
    private Transform posicion_siguiente;
    public float distancia;
   
    
    //para crear la busqueda del jugador

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        posicion_siguiente = posicion_final;
        
    }

    void Update()
    {
        distancia = Mathf.Abs(Player.transform.position.x - rata.transform.position.x);
        if (distancia < radio_busqueda) 

        {
            if (Player.transform.position.x - rata.transform.position.x<0)
            {
                rb.transform.localScale = new Vector2(1, 1);
            }
            else if(Player.transform.position.x - rata.transform.position.x > 0)
            {
                rb.transform.localScale = new Vector2(-1, 1);
            }
            rata.transform.position = Vector2.MoveTowards(rata.transform.position, Player.transform.position, Time.deltaTime * velocidad);
            
        }
        if(distancia > radio_busqueda)
        {
            if (posicion_siguiente.transform.position.x - rata.transform.position.x < 0)
            {
                rb.transform.localScale = new Vector2(1, 1);
            }
            else if (posicion_siguiente.transform.position.x - rata.transform.position.x > 0)
            {
                rb.transform.localScale = new Vector2(-1, 1);
            }
            rata.transform.position = Vector2.MoveTowards(rata.transform.position, posicion_siguiente.position, Time.deltaTime * velocidad);
            if (rata.transform.position == posicion_siguiente.position)
            {
                posicion_siguiente = posicion_siguiente == posicion_final ? posicion_inicial : posicion_final;
            }
        }
        
    }    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio_busqueda);
        
    }
}
