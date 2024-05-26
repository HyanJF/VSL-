using System.Collections;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    public GameObject AOEBoomPrefab;
    public bool hitsPlayer = false;

    private void Update()
    {
        StartCoroutine(Lifetime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitsPlayer)
        {
            if (other.CompareTag("Enemy"))
            {            
                AOEBoomPrefab.transform.position = this.transform.position;
                Instantiate(AOEBoomPrefab);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                AOEBoomPrefab.transform.position = this.transform.position;
                Instantiate(AOEBoomPrefab);
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