using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Phase1Movement : MonoBehaviour
{
    private GameObject centerObject;
    public float radius;
    public float speed;
    public string targetTag = "Player";

    private float angle = 0f;

    private void Awake()
    {
        GetComponent<B2Phase2Movement>().enabled = false;
        centerObject = GameObject.FindGameObjectWithTag(targetTag);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<B2Phase2Movement>().enabled = true;
            GetComponent<B2Phase1Movement>().enabled = false;
        }

        angle += speed * Time.deltaTime;


        float x = centerObject.transform.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.transform.position.y + Mathf.Sin(angle) * radius;


        transform.position = new Vector3(x, y, transform.position.z);

        // Esto es para que el jefe mire hacia el jugador, pero a la mera se ve raro dependiendo del sprite
        //transform.right = centerObject.position - transform.position;
        
    }
}
