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
            default:
                break;
        }
    }

    void Find()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(stats.MovementSpeed * Time.deltaTime * direction.normalized);
    }

    float rotationPoint;
    float rotationPointX;
    float rotationPointY; 
    [SerializeField] float radius;   
     [SerializeField] float rotationSpeed;  
    void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            aim.FireBullet(bulletPrefab, bulletSpeed, target.transform);
        }
        rotationPointX = Mathf.Sin(rotationPoint) * radius + target.transform.position.x;
        rotationPointY = Mathf.Cos(rotationPoint) * radius + target.transform.position.y;
        transform.position = new Vector2(rotationPointX, rotationPointY);
        rotationPoint += (rotationSpeed * Time.deltaTime) / radius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            rotationPoint = transform.position.x;
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
