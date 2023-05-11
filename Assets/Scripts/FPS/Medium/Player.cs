using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float bulletSpeed = 200;


    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = PoolManager.Instance.RequestBullet();
            bullet.transform.position = Vector3.forward * bulletSpeed * Time.deltaTime + gameObject.transform.localPosition + new Vector3(0, 0, 1);
        }
    }
}
