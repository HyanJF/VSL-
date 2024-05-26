using System.Collections;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public int dmg;
    public bool hitsPlayer = false;


    private void Start()
    {
        StartCoroutine(Lifetime());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitsPlayer)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyHealer"))
            {
                other.GetComponent<EnemyStats>().health -= dmg;
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Stats.instance.takeDamage(dmg);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
