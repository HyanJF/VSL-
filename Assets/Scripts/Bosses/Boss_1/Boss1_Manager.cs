using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Manager : MonoBehaviour
{

    public enum movementState
    {
        stand,//Stands in position
        run,//Runs away from the player
        chase, //Chase the player
        around//Moves around the player
    }
    public enum attack
    {
        spinningProjectiles,
        damageHeal,
        destructibleRing,
        dotaoe
    }
    public attack attackState;
    public movementState currentMove;
    public float maxHp;
    float currentHp;
    public float moveSpeed = 0;     
    public Transform player;

    private void Start()
    {
        selfHeal = false;
        currentHp = maxHp;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        switch (attackState)
        {
            case attack.spinningProjectiles:
                StartCoroutine(SpiningProjectiles());
                break;
            case attack.damageHeal:
                StartCoroutine (DamageHeal());
                break;
            case attack.dotaoe:
                StartCoroutine(DOTAOE());
                break;
            case attack.destructibleRing:
                StartCoroutine(DestructibleRing());
                break;
            default:
                Debug.Log("something went wrong");
                break;
        }
    }

    private void Update()
    {
        switch (currentMove)
        {
            case movementState.stand:
                Stand();
                break; 
            case movementState.run:
                Run();
                break;
            case movementState.chase:
                Chase();
                break;
            case movementState.around:
                Around();
                break;
            default :
                Debug.Log("something went wrong");
                break;
        }
    }

    public void DealDamage(float damage)
    {
        currentHp -= selfHeal ? -damage : damage;
        //ToDo Update HP bar
    }

    #region Movement
    public void Stand()
    {
        //xd
        transform.position = transform.position;
    }

    Vector2 move;
    public void Run()
    {
        move = (transform.position - player.position);
        transform.position += moveSpeed * Time.deltaTime * (Vector3)move.normalized;
    }

    public void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public float rotationSpeed;
    public float radius;
    float rotationPointX;
    float rotationPointY;
    float rotationPoint;
    
    public void Around()
    {
        rotationPointX = Mathf.Sin(rotationPoint) * radius + player.position.x;
        rotationPointY = Mathf.Cos(rotationPoint) * radius + player.position.y;
        transform.position = new Vector2(rotationPointX, rotationPointY);
        rotationPoint += (rotationSpeed * Time.deltaTime) / radius;
    }

    #endregion

    #region Attacks
    [SerializeField] private EnemyAim aim;

    #region SpiningProjectiles
    [SerializeField] private int numberProjectiles;
    [SerializeField] private int numberRounds;
    [SerializeField] private GameObject spiningProjectilePrefab;
    [SerializeField] private float spiningProjectilesSpeed;
    IEnumerator SpiningProjectiles()
    {
        currentMove = movementState.chase;
        
        for (float i = 0; i < numberProjectiles; i++)
        { 
            for (float j = 0; j < numberRounds; j++)
            {
                float x = (float)Math.Cos(j + (i/Math.PI));
                float y = (float)Math.Sin(j + (i / Math.PI));
                Vector2 spawnPos = new Vector2(x+transform.position.x,y + transform.position.y);
                GameObject bullet = Instantiate(spiningProjectilePrefab, spawnPos, spiningProjectilePrefab.transform.rotation);
                Vector2 direction = ((Vector2)transform.position - spawnPos);
                bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized*spiningProjectilesSpeed);
                
            }
            yield return new WaitForSeconds(0.3f);
        }



        yield return new WaitForSeconds(5);
        NextAttack(0);
    }
    #endregion

    #region DamageHeal
    bool selfHeal;
    IEnumerator DamageHeal()
    {
        currentMove = movementState.stand;
        selfHeal = true;
        float randomDelay = UnityEngine.Random.Range(1, 3);
        yield return new WaitForSeconds(randomDelay);
        selfHeal = false;
        NextAttack(1);
        
    }
    #endregion

    #region DOTAOE
    [SerializeField] private GameObject dotaoePrefab;
    public int totalShootsdotaoe;
    public float dotaoeSpeed;
    IEnumerator DOTAOE()
    {
        NextMove();
        int i = 0;
        while (i < totalShootsdotaoe)
        {
            aim.FireBullet(dotaoePrefab, dotaoeSpeed, player);
            int randomDelay = UnityEngine.Random.Range(1, 3);
            yield return new WaitForSeconds(randomDelay);
            i++;
        }
        int randomCooldown = UnityEngine.Random.Range(3, 5);
        yield return new WaitForSeconds(randomCooldown);
        NextAttack(2);
    }
    #endregion

    #region DestructibleRing
    [SerializeField] private GameObject destructibleRingPrefab;
    public int totalShootsDR;
    public float destrutibleRingSpeed;
    IEnumerator DestructibleRing()
    {
        NextMove();
        int i = 0;
        while (i < totalShootsDR)
        {
            aim.FireBullet(destructibleRingPrefab, destrutibleRingSpeed, player);
            int randomDelay = UnityEngine.Random.Range(1,3);
            yield return new WaitForSeconds(randomDelay);
            i++;
        }
        int randomCooldown = UnityEngine.Random.Range(3, 5);
        yield return new WaitForSeconds(randomCooldown);
        NextAttack(3);
    }
    #endregion

    #region Change Status
    void NextAttack(int current)
    {
        int randomIndex;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, 4);
        } while (randomIndex == current);
        switch (randomIndex)
        {
            case 0:
                StartCoroutine(SpiningProjectiles());   
                break;
             case 1:
                StartCoroutine(DamageHeal());
                break;
            case 2:
                StartCoroutine(DOTAOE());
                break;
            case 3:
                StartCoroutine(DestructibleRing());
                break;
            default:
                Debug.Log("Something unexpected happend");
                break;
        }
    }

    void NextMove()
    {
       
        int randomIndex = UnityEngine.Random.Range(1, 4);
        switch (randomIndex)
        {
            case 1:
                currentMove = movementState.run; 
                break;
            case 2:
                currentMove = movementState.chase; 
                break;
            case 3:
                currentMove = movementState.around; 
                break;
            default:
                Debug.Log("Something unexpected happend");
                break;
        }
    }
    #endregion

    #endregion
}
