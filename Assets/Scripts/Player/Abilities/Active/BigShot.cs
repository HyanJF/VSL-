using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu]
public class BigShot : ActiveAbility
{
    public GameObject bullet;
    public float bulletSpeed;
    public override void ActivateAbility(GameObject player)
    {
        Debug.Log("Shoot go big");
        player.GetComponentInChildren<PointAndShoot>().FireBullet(bullet, bulletSpeed);
    }
}
