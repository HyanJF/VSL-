using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject bulletStart;
    public GameObject rotationPoint;
    Vector3 difference;
    float rotationZ;
    public float bulletSpeed;
    
    public void FireBullet(GameObject _bulletPrefab, float _bulletSpeed, Transform player)
    {
        difference = player.position - rotationPoint.transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed * Time.deltaTime;
    }
}
