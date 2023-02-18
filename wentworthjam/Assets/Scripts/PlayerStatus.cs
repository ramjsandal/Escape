using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float startingHealth;

    public float _currentHealth;
    
    private bool _dead;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
        {
            _dead = true;
        }
    }

    public void DealDamage(float amt)
    {
        _currentHealth -= amt;
    }

    public bool IsDead()
    {
        return _dead;
    }

    public float PercentHealth()
    {
        return _currentHealth / startingHealth;
    }
}
