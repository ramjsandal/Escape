using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip bulletSFX;
    [SerializeField] private float cooldown;
    private float _currentCooldown;
    void Start()
    {
        _currentCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _currentCooldown <= 0)
        {
            Transform t = transform;
            GameObject instance = Instantiate(bullet, 
                t.position + t.forward, t.rotation);
            _currentCooldown = cooldown;
        }

        _currentCooldown -= Time.deltaTime;
    }
}
