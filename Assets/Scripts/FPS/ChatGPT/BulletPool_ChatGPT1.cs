using UnityEngine;
using System.Collections;

public class BulletPool_ChatGPT1 : MonoBehaviour
{
    public GameObject bulletPrefab; // the prefab for the bullet
    public int poolSize = 20; // the size of the pool
    private GameObject[] bulletPool; // the pool of bullets
    private int currentBullet = 0; // the current bullet in the pool

    void Start()
    {
        // create the bullet pool
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = (GameObject)Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get the next bullet from the pool
            GameObject bullet = bulletPool[currentBullet];
            currentBullet++;
            if (currentBullet >= poolSize)
            {
                currentBullet = 0;
            }

            // activate the bullet and set its position
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.transform.Translate(Vector3.right);
        }
    }
}

