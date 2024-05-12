
using UnityEngine;

public class OrbContactDamage : MonoBehaviour
{
    public int DMG;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Touched an enemy");
            other.GetComponent<EnemyStats>().health -= DMG;
        }

    }
}