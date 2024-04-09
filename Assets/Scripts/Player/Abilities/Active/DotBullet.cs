using System.Collections;
using System.Collections.Generic;
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

//Temporary placed BigShot.cs script here in order to test DOT, CreateAssetMenu does not work for me, idk why
/**
using System.Collections;
using System.Collections.Generic;
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
**/