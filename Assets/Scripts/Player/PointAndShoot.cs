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

    public float bulletSpeed;


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        crosshair.transform.position = (Vector2)playerCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = crosshair.transform.position - rotationPoint.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
        }
    }


    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * Time.deltaTime;
    }

    public void FireBullet(Vector2 direction, float rotationZ, GameObject _bulletPrefab, float _bulletSpeed)
    {
        GameObject bullet = Instantiate(_bulletPrefab) as GameObject;
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed * Time.deltaTime;
    }
}
