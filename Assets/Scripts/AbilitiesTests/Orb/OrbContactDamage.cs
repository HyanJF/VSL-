
using UnityEngine;

public class OrbContactDamage : MonoBehaviour
{
    public float DMG;
    public bool hitsPlayer = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitsPlayer)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyStats>().health -= DMG *Time.deltaTime;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Stats.instance.takeDamage(DMG * Time.deltaTime);
            }
        }

    }
}
