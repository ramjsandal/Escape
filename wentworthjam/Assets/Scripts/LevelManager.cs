using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    [SerializeField] private Image healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStatus.IsDead())
        {
            Debug.Log("Player is dead");
        }

        healthbar.fillAmount = _playerStatus.PercentHealth();
    }
}
