using System.Collections;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    public GameObject AOEBoomPrefab;

    private void Update()
    {
        StartCoroutine(Lifetime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Boom^2");
            
            AOEBoomPrefab.transform.position = this.transform.position;
            Instantiate(AOEBoomPrefab);
            Destroy(gameObject);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}