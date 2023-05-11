using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private List<GameObject> _bulletPool;
    [SerializeField] private int _bulletCount = 0;

    private static PoolManager _instance;   //Singelton
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Pool Manager is Null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _bulletPool = GenerateBullets(_bulletCount);
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RequestBullet();
    //    }
    //}

    private List<GameObject> GenerateBullets(int numOfBullets)
    {
        for(int i = 0 ; i < numOfBullets; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }
        return _bulletPool;
    }

    public GameObject RequestBullet()
    {
        foreach(var bullet in _bulletPool)
        {
            if(bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(_bulletPrefab);
        newBullet.transform.parent = _bulletContainer.transform;
        newBullet.transform.parent = null;      //To stop it from following the player while he is moving (after shooting)
        _bulletPool.Add(newBullet);
        return newBullet;
    }
}

