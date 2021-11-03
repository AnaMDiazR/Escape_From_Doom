using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController: MonoBehaviour
{
    public float High_Jump; 
    public float Speed_Move;
    private Rigidbody2D RB;// parametros de velocidad de movimiento  y altura de salto
    private Animator anim;
    private bool toco_piso;//parametreos de animacion
    private int vidas = 3;
    private Vector2  pos_anterior;
    public Transform validador_piso;
    public float radio_validacion;
    public LayerMask capa_piso;
    private bool recibe_daño = false;
    private int puntos = 0;
    public const string MONEDA = "Moneda";
    private int valor_punto = 10;

    //asignar o retornar vidas
    public int Vidas { get => vidas; set => vidas = value; }

    public int Puntos
    {
        get
        {
            return puntos;
        }
        set
        {

        }
    }

    void Start()
    {
        pos_anterior = this.transform.position;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        toco_piso = Physics2D.OverlapCircle(validador_piso.position,radio_validacion,capa_piso);
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.transform.tag.Equals("Piso_Movil"))
        {
            transform.parent = other.transform;

        }
        else
        {
            transform.parent = null;
        }
        if (other.transform.tag.Equals("Limite"))
        {
            this.transform.position = pos_anterior;
            vidas--;
        }

        if(other.gameObject.tag.Equals("Enemigo"))
        {
            recibe_daño = true;
            vidas--;
        }

        if (other.gameObject.tag.Equals("Calavera"))
        {
            recibe_daño = true;
            vidas--;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemigo"))
        {
            Vidas--;
            recibe_daño = true;
        }

        if (collision.tag.Equals("Calavera"))
        {
            Vidas--;
            recibe_daño = true;
        }

        if (collision.tag.Equals(MONEDA))
        {
            collision.gameObject.SetActive(false);
            puntos+= valor_punto;
        }
    }

    void Update()
    {
        if (toco_piso)
        {
            anim.SetInteger("Estado",0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && toco_piso) 
        {
            RB.velocity = new Vector2(RB.velocity.x, High_Jump);
            toco_piso = false;
            anim.SetInteger("Estado", 2);
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            RB.velocity = new Vector2(Speed_Move,RB.velocity.y);
            RB.transform.localScale = new Vector2(1,1);
            anim.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity = new Vector2(-Speed_Move, RB.velocity.y);
            RB.transform.localScale = new Vector2(-1, 1);
            anim.SetInteger("Estado", 1);
        }
        if (recibe_daño)
        {
            anim.SetInteger("Estado", 3);
            recibe_daño = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio_validacion);

    }
}
    

