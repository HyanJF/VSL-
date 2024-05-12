using System.Collections;

using UnityEngine;

public class ExplosiveAOE : MonoBehaviour
{
    public int DMG;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("And it went boom");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().health -= DMG;
        }
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}