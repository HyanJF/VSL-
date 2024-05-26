using System.Collections;
using UnityEngine;

public class ChaserBehaviour : EnemyBehaviour
{
    private GameObject targetObject;
    [SerializeField] string targetTag;
    [SerializeField] EnemyStats ES;
    bool isDamageReady = true;

    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        stats = GetComponent<EnemyStats>();
        ES = GetComponent<EnemyStats>();
    }


    public override void Behaviour()
    {
        if (targetObject != null)
        {
            Vector3 direction = targetObject.transform.position - transform.position;
            transform.Translate(stats.MovementSpeed * Time.deltaTime * direction.normalized);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDamageReady)
        {
            isDamageReady = false;
            Stats.instance.takeDamage(10);
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3);
        isDamageReady = true;
    }
}
