using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    public PlayerController player;
    public GameObject Barra_vida;
    private Animator anim;
    public const string Estado_vidas = "Vidas";
    void Start()
    {
        anim = Barra_vida.GetComponent<Animator>(); 
    }

    
    void Update()
    {
        anim.SetInteger(Estado_vidas, player.Vidas);// usar las vidas que declaramos en el playercontroller
    }
}
