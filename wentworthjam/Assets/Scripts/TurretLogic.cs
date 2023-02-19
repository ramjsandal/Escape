using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : Subject
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldown;
    [SerializeField] private float minDistance;

    private bool _triggered = false;
    private GameObject _player;
    private Transform _playerTransform;
    private Transform _root;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _root = this.gameObject.transform.GetChild(1);
        InvokeRepeating("_fireBullet", cooldown, cooldown);
    }
    
    void Update()
    {
        if (!_triggered)
        {
            Vector3 playerPos = _player.transform.position;
            Vector3 thisPos = this.transform.position;
            // Get the distance to the player
            float distance = Vector3.Distance(thisPos, playerPos);
            float angle = Vector3.SignedAngle(_player.transform.forward, thisPos - playerPos, Vector3.up);

            // If we are close to the player, then we notify the baby
            // if we are to the left, right, in front of, or behind the player
            if (distance < minDistance)
            {
                Zone zone = FindZone(angle);
                Notify(this, zone);
                _triggered = true;
            }
        }
        

    }

    void _fireBullet()
    {
        Vector3 playerPos = _playerTransform.position;
        Vector3 turretPos = this.transform.position;
        Vector3 towardsPlayer =
            new Vector3(playerPos.x - turretPos.x, playerPos.y - turretPos.y, playerPos.z - turretPos.z).normalized;
        Vector3 rootPos = _root.position;
        Vector3 firePos = new Vector3(rootPos.x, rootPos.y, rootPos.z);
        Instantiate(bullet, firePos, Quaternion.LookRotation(towardsPlayer));
    }

    Zone FindZone(float signedAngle)
    {
        // In front of the player
        if (signedAngle > 0)
        {
            if (signedAngle < 90)
            {
                return Zone.FrontRight;
            }
            else
            {
                return Zone.BackRight;
            }
        }
        // Behind the player
        else
        {
            if (signedAngle > -90)
            {
                return Zone.FrontLeft;
            }
            else
            {
                return Zone.BackLeft;
            }
        }
    }
}
