using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpStats : MonoBehaviour
{
    [SerializeField] private float xpValeu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Toco al jugador");
        }
    }
}
