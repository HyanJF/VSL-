using System.Collections;

using UnityEngine;

public class AOE : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("ded");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StatusEffectManager>().ApplyDOT(4);
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
