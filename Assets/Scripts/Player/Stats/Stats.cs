using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // variables
    [SerializeField] private float life;
    [SerializeField] private int lvl;
    [SerializeField] private float speed;
    [SerializeField] private float DeadAnimationTime;

    public int deathCounter;
    // variables balas 

    // Funciones
    private void Start()
    {
        // provicional
        takeDamage(0);
    }

    public void takeDamage(float damage)
    {
        life -= damage;
        if(life < 0)
        {
            life = 0;
            StartCoroutine(dead());
        }
    }

    public IEnumerator dead()
    {
        yield return new WaitForSeconds(DeadAnimationTime);
        Destroy(gameObject);
    }
    
    public float Speed()
    {
        return speed;
    }
    
    public void lvlUpdate()
    {
        lvl++;
    }
    public int LvlActual()
    {
        return lvl;
    }
}
