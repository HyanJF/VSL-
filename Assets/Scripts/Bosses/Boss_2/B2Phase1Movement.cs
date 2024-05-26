using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Phase1Movement : MonoBehaviour
{
    private GameObject centerObject;
    public float radius;
    public float speed;
    public string targetTag = "Player";
    public Animator animator;

    private float angle = 0f;
    int counter = 0;

    private void Awake()
    {
        GetComponent<B2Phase2Movement>().enabled = false;
        centerObject = GameObject.FindGameObjectWithTag(targetTag);
    }

    void Update()
    {

        angle += speed * Time.deltaTime;


        float x = centerObject.transform.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.transform.position.y + Mathf.Sin(angle) * radius;


        transform.position = new Vector3(x, y, transform.position.z);

        // Esto es para que el jefe mire hacia el jugador, pero a la mera se ve raro dependiendo del sprite
        //transform.right = centerObject.position - transform.position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        counter++;
        if (counter >= 25)
        {
            GetComponent<B2Phase2Movement>().enabled = true;
            animator.SetBool("IsPhase2", true);
            GetComponent<B2Phase1Movement>().enabled = false;
        }
    }
}
