using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Sniper : EnemyBehaviour
{
    public enum State
    {
        finding,
        shooting,
        running
    }
    EnemyAim aim;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float shootCooldown;
    float shootTimer = 0;
    public State currentSate;
    private CircleCollider2D detector;
    private SecondCollider runDetector;
    public string targetTag;
    private GameObject target;

    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        aim = GetComponent<EnemyAim>();
        currentSate = State.finding;
        detector = GetComponent<CircleCollider2D>();  
        runDetector = GetComponentInChildren<SecondCollider>();
        runDetector.Tag = targetTag;

    }

    public override void Behaviour()
    {   
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag(targetTag);
            currentSate = State.finding;
        }
        switch (currentSate)
        {
            case State.finding:
                Find();
                break;
            case State.shooting:
                Shooting();
                break;
            case State.running:
                Run();
                break;
            default:
                break;
        }
    }

    void Find()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(stats.MovementSpeed * Time.deltaTime * direction.normalized);
    }
    void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            aim.FireBullet(bulletPrefab, bulletSpeed, target.transform);
        }
    }
    public void Run()
    {
        Vector2 move = (transform.position - target.transform.position);
        transform.position += stats.movementSpeed * Time.deltaTime * (Vector3)move.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("sus");
            currentSate = State.shooting;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            currentSate = State.finding;
        }
    }
}
