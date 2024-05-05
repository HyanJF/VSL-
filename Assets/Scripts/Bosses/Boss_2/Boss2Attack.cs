using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform target; 
    public float fireInterval = 1f; 
    public float bulletSpeed = 10f; 

    private float timer = 0f;

    void Update()
    {

        if (target == null)
            return;

        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            timer = 0f;

            // Direcction a donde disparar
            Vector3 direction = (target.position - transform.position).normalized;

            // Mandamos llamar a la bala
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);


            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }
}
