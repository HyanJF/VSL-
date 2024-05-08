using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Phase2Movement : MonoBehaviour
{
    public Transform jugador; 
    public float esperaInicial = 1f; 
    public float duracionTemblor = 0.5f; 
    public float velocidadMovimiento = 5f; 

    private float tiempoEspera;
    private bool temblando = false;

    void Start()
    {
        // Iniciar la corutina
        StartCoroutine(CicloMovimiento());
    }

    IEnumerator CicloMovimiento()
    {
        while (true)
        {

            yield return new WaitForSeconds(esperaInicial);


            temblando = true;
            yield return new WaitForSeconds(duracionTemblor);
            temblando = false;

            // Obtener la posición del jugador
            Vector3 posicionJugador = jugador.position;

            // Moverse hacia la posición del jugador
            while (Vector3.Distance(transform.position, posicionJugador) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicionJugador, velocidadMovimiento * Time.deltaTime);
                yield return null;
            }
        }
    }

    void Update()
    {
        if (temblando)
        {
            // Tiembla
            float temblorX = Random.Range(-0.1f, 0.1f);
            float temblorY = Random.Range(-0.1f, 0.1f);
            transform.position += new Vector3(temblorX, temblorY, 0f);
        }
    }
}
