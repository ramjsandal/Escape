using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBulletLogic : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = transform;
        t.position += t.forward * (bulletSpeed * Time.deltaTime);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
