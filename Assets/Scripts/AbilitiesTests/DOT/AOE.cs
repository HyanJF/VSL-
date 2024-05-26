using System.Collections;

using UnityEngine;

public class AOE : MonoBehaviour
{
    public bool hitsPlayer = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!hitsPlayer)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyHealer"))
            {
                other.GetComponent<StatusEffectManager>().ApplyDOT(4);
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<StatusEffectManager>().ApplyDOT(4);
            }
        }
       
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
