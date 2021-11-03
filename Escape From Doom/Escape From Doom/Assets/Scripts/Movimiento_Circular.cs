using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Circular : MonoBehaviour
{
    public Transform centro;
    private float x0, y0, angulo, tiempo, r, x, y;

    void Start()
    {
        r = 3f;
        angulo = Mathf.PI / 4;

        x0 = centro.transform.position.x;
        y0 = centro.transform.position.y;
        tiempo = 0f;


    }


    void FixedUpdate()
    {
        if (tiempo >= 0.1f)
        {
            x = x0 + r * Mathf.Cos(angulo);
            y = y0 + r * Mathf.Sin(angulo);
            angulo = (angulo - Mathf.PI / 32) % (2 * Mathf.PI);
            transform.localPosition = new Vector2(x, y);
            tiempo = 0f;
        }
        else
        {
            tiempo += Time.deltaTime;
        }
    }
}
