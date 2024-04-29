using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DOTProjectile : MonoBehaviour
{
    public GameObject AOEPrefab;
    public string tag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag))
        {
            Debug.Log("fire");
            other.GetComponent<StatusEffectManager>().ApplyDOT(4);
            AOEPrefab.transform.position = this.transform.position;
            Instantiate(AOEPrefab);
            Destroy(gameObject);
        }
    }
}
