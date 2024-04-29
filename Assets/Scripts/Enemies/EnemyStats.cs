using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float movementSpeed;
    public int attack;
    public float attackSpeed;
    public int health;
    public EnemyBehaviour behavior;

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