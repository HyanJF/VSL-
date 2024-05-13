
using UnityEngine;


[CreateAssetMenu]
public class DotBullet : ActiveAbility
{
    public GameObject bullet;
    public float bulletSpeed;
    public override void ActivateAbility(GameObject player)
    {
        Debug.Log("Shoot fire");
        player.GetComponentInChildren<PointAndShoot>().FireBullet(bullet, bulletSpeed);
    }
}