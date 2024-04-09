using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    void Start()
    {
        health = maxHealth;
    }
}
