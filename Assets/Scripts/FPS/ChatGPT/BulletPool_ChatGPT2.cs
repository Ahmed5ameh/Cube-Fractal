using UnityEngine;
using System.Collections;

public class BulletPool_ChatGPT2 : MonoBehaviour
{

    public GameObject bulletPrefab;
    public int bulletPoolSize = 20;
    public float bulletLifetime = 5f;

    private GameObject[] bulletPool;
    private int currentBullet = 0;

    void Start()
    {
        bulletPool = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bulletPool[i] = (GameObject)Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        bulletPool[currentBullet].transform.position = transform.position;
        bulletPool[currentBullet].transform.rotation = transform.rotation;
        bulletPool[currentBullet].SetActive(true);
        StartCoroutine(DestroyBullet(bulletPool[currentBullet], bulletLifetime));
        currentBullet++;
        if (currentBullet >= bulletPoolSize)
        {
            currentBullet = 0;
        }
    }

    IEnumerator DestroyBullet(GameObject bullet, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        bullet.SetActive(false);
    }
}