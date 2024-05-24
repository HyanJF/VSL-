using System.Collections;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public int dmg;

    private void Update()
    {
        StartCoroutine(Lifetime());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().health -= dmg;
            Destroy(gameObject);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
