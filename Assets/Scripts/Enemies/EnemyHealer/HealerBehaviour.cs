using UnityEngine;

public class HealerBehaviour : EnemyBehaviour
{
    private GameObject target = null;
    private EnemyStats targetStats;
    [SerializeField] private float healCooldown;
    private CircleCollider2D detector;
    private float healTimer = 0;
    [SerializeField] string targetTag;
    private bool isOnRange;
    [SerializeField] private int healAmount;
    public Animator animator;

    private void Awake()
    {
        detector = GetComponent<CircleCollider2D>();  
        stats = GetComponent<EnemyStats>();
    }

    public override void Behaviour()
    {
        if (target == null)
        {
            try
            {
                isOnRange = false;
                target = GameObject.FindGameObjectWithTag(targetTag);
                targetStats = target.GetComponent<EnemyStats>();
            }catch(System.Exception)
            {
                Debug.Log("No hay enemigos xd");
            }
        }
        else
        {
            if (isOnRange)
            {
                animator.SetBool("IsMoving", false);
                healTimer += Time.deltaTime;
                if (healCooldown <= healTimer)
                {
                    animator.SetTrigger("Heal");
                    targetStats.Health += healAmount;
                    stats.Health += healAmount;
                    healTimer = 0;
                }
            }
            else
            {
                animator.SetBool("IsMoving", true);
                Vector3 direction = target.transform.position - transform.position;
                transform.Translate(stats.MovementSpeed * Time.deltaTime * direction.normalized);
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            isOnRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(targetTag))
        {
            isOnRange = false;
        }
    }
}

