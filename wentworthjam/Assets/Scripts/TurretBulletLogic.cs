using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        transform.position += transform.forward * (bulletSpeed * Time.deltaTime);
    }
}
