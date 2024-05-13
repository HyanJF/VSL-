// Todo esto es robado
using UnityEngine;

public class OrbitatingOrb : MonoBehaviour
{
    public Transform centerObject;
    public float radius;
    public float speed;

    private float angle = 0f;
    
    private void Awake()
    {
        GetComponent<OrbitatingOrb>().enabled = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<OrbitatingOrb>().enabled = true;
            GetComponent<OrbitatingOrb>().enabled = false;
        }

        angle += speed * Time.deltaTime;


        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;


        transform.position = new Vector3(x, y, transform.position.z);

        // Esto es para que el jefe mire hacia el jugador, pero a la mera se ve raro dependiendo del sprite
        //transform.right = centerObject.position - transform.position;

        
    }
   
    

}
