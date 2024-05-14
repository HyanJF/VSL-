using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpStats : MonoBehaviour
{
    [SerializeField] private int xpValeu;
    private void Start()
    {
        xpValeu = Random.Range(1, 5);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponentInChildren<xpManager>().AddXp(xpValeu);
        }
    }
}
