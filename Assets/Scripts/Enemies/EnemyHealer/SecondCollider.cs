using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCollider : MonoBehaviour
{
    private string targetTag;
    private CircleCollider2D detector;
    private Sniper parent;

    private void Awake()
    {
        detector = GetComponent<CircleCollider2D>();    
        parent = GetComponentInParent<Sniper>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag(targetTag))
        {
            parent.currentSate = Sniper.State.running;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            parent.currentSate = Sniper.State.shooting;
        }
    }

    public string Tag { set { targetTag = value; } }
}
