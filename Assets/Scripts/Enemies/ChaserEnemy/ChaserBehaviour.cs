using UnityEngine;

public class ChaserBehaviour : EnemyBehaviour
{
    private GameObject targetObject;
    [SerializeField] string targetTag;

    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        stats = GetComponent<EnemyStats>();
    }


    public override void Behaviour()
    {
        if (targetObject != null)
        {
            Vector3 direction = targetObject.transform.position - transform.position;
            transform.Translate(stats.MovementSpeed * Time.deltaTime * direction.normalized);
        }
    }
}
