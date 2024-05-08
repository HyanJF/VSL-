using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform targetObject;
    public EnemyStats speed;
    private void Awake()
    {
        GetComponent<EnemyStats>();
    }
    public virtual void behavior()
    {

    }
    private void Update()
    {
        if (targetObject != null)
        {
            Vector3 direction = targetObject.position - transform.position;
            transform.Translate(direction.normalized * speed.MovementSpeed * Time.deltaTime);
        }
    }
}
