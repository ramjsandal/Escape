using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretBulletLogic : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float bulletSpeed;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            _player.position, bulletSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = transform;
        t.position += t.forward * (bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            Destroy(this.gameObject);
        }
    }
}
