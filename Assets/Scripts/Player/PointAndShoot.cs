using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshair;
    [SerializeField] Camera playerCamera;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public GameObject rotationPoint;
    Vector3 difference;
    float rotationZ;
    bool isBulletReady = false;
    public float bulletDelay;
    float bulletTimer = 0;

    public float bulletSpeed;


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        crosshair.transform.position = (Vector2)playerCamera.ScreenToWorldPoint(Input.mousePosition);

        difference = crosshair.transform.position - rotationPoint.transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        if(Input.GetMouseButton(0))
        {
            if (!isBulletReady)
            {
                bulletTimer += Time.deltaTime;
            }
            else
            {
                FireBullet(bulletPrefab, bulletSpeed);
                bulletTimer = 0;
            }
            isBulletReady = bulletDelay < bulletTimer;
        }
       
    }

    private void OnMouseDown()
    {
        
    }

    public void FireBullet(GameObject _bulletPrefab, float _bulletSpeed)
    {
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed;
        bullet.GetComponent<DestroyBullets>();
    }
}
