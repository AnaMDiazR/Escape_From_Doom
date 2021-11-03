using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector3 Desplazamiento;
   
    void FixedUpdate()
    {
        transform.position = new Vector3 (Player.position.x + Desplazamiento.x, Player.position.y + Desplazamiento.y,Desplazamiento.z);
    }
}
   
