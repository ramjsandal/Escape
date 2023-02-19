using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Observer
{
    [SerializeField] private AudioClip[] frontLeft;
    [SerializeField] private AudioClip[] frontRight;
    [SerializeField] private AudioClip[] backLeft;
    [SerializeField] private AudioClip[] backRight;
    private AudioClip _current;
    
    void Start()
    {
        foreach (var obj in FindObjectsOfType<TurretLogic>())
        {
            obj.RegisterObserver(this);
        }
    }
    

    public override void OnNotify(object value, Zone zoneType)
    {
        int index;
        switch (zoneType)
        {
            case Zone.FrontLeft:
                index = Random.Range(0, frontLeft.Length);
                _current = frontLeft[index];
                Debug.Log("Front Left");
                break;
            case Zone.BackLeft:
                index = Random.Range(0, backLeft.Length);
                _current = backLeft[index];
                Debug.Log("Back Left");
                break;
            case Zone.BackRight:
                index = Random.Range(0, backRight.Length);
                _current = backRight[index];
                Debug.Log("Back Right");
                break;
            case Zone.FrontRight:
                index = Random.Range(0, frontRight.Length);
                _current = frontRight[index];
                Debug.Log("Front Right");
                break;
        }
        
        AudioSource.PlayClipAtPoint(_current, this.transform.position);
        
    }
}
