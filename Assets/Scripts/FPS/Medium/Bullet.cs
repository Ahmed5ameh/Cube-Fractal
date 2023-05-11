using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10.0f;
    private void OnEnable()
    {
        Invoke("Hide", 1f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
