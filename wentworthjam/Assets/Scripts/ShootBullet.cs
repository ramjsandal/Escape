using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip bulletSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform t = transform;
            GameObject instance = Instantiate(bullet, 
                t.position + t.forward, t.rotation);
        }
    }
}
