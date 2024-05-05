using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    public Transform centerObject;
    public float radius;
    public float speed;

    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime;


        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;


        transform.position = new Vector3(x, y, transform.position.z);

        // Esto es para que el jefe mire hacia el jugador, pero a la mera se ve raro dependiendo del sprite
        //transform.right = centerObject.position - transform.position;
        
    }
}
