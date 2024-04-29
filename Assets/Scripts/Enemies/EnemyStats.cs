using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float movementSpeed;
    private int attack;
    private float attackSpeed;
    private int health;
    public EnemyBehavior behavior;

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed  = value; }   
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; } 
    }
}