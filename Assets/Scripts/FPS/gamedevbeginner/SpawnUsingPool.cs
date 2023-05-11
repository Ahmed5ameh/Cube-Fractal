using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class SpawnUsingPool : MonoBehaviour
{
    /// <summary>
    /// https://www.youtube.com/watch?v=7EZ2F-TzHYw     //A GOOD VIDEO (BUT NOT THE BEST), AS FAR AS I CAN SEE ATM 13/1/2023
    /// </summary>
    public GameObject objectPrefab;
    ObjectPool<GameObject> objectPool;
    void Awake()
    {
        objectPool = new ObjectPool<GameObject>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
    }

    #region BHBD_B7AWEL_A48ALOOOO
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        GameObject Bullet = objectPool.Get();
    //    }
    //} 
    #endregion

    GameObject OnObjectCreate()     //We can point to this function using "Func" delegate => REASON: it takes no arguments, and returns <T>.
    {
        GameObject newObject = Instantiate(objectPrefab);
        newObject.AddComponent<PoolObject>().myPool = objectPool;       //send the list to the other script, dont know why yet.
        return newObject;
    }
    void OnTake(GameObject poolObject)
    {
        poolObject.SetActive(true);
    }
    void OnRelease(GameObject poolObject)
    {
        poolObject.SetActive(false);
    }
    void OnObjectDestroy(GameObject poolObject)
    {
        Destroy(poolObject);
    }
}