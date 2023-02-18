using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldown;
    
    private GameObject _player;
    private Transform _playerTransform;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        InvokeRepeating("_fireBullet", cooldown, cooldown);
    }
    
    void Update()
    {
    }

    void _fireBullet()
    {
        Vector3 playerPos = _playerTransform.position;
        Vector3 turretPos = this.transform.position;
        Vector3 towardsPlayer =
            new Vector3(playerPos.x - turretPos.x, playerPos.y - turretPos.y, playerPos.z - turretPos.z).normalized;

        Instantiate(bullet, turretPos, Quaternion.LookRotation(towardsPlayer));
    }
}
