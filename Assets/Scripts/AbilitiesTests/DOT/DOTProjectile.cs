using System.Collections;
using UnityEngine;

public class DOTProjectile : MonoBehaviour
{
    public GameObject AOEPrefab;

    private void Update()
    {
        StartCoroutine(Lifetime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("fire");
            other.GetComponent<StatusEffectManager>().ApplyDOT(4);
            AOEPrefab.transform.position = this.transform.position;
            Instantiate(AOEPrefab);
            Destroy(gameObject);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
