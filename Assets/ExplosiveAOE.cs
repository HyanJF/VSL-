using System.Collections;

using UnityEngine;

public class ExplosiveAOE : MonoBehaviour
{
    public int DMG;
    public bool hitsPlayer = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitsPlayer)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyHealer"))
            {
                other.GetComponent<EnemyStats>().health -= DMG;
            }

        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Stats.instance.takeDamage(DMG);
            }
        }
        StartCoroutine(WaitForIt());
        
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}