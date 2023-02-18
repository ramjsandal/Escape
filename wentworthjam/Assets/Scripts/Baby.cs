using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : Observer
{
    [SerializeField] private AudioClip frontLeft;
    [SerializeField] private AudioClip frontRight;
    [SerializeField] private AudioClip backLeft;
    [SerializeField] private AudioClip backRight;
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
        switch (zoneType)
        {
            case Zone.FrontLeft:
                _current = frontLeft;
                Debug.Log("Front Left");
                break;
            case Zone.BackLeft:
                _current = backLeft;
                Debug.Log("Back Left");
                break;
            case Zone.BackRight:
                _current = backRight;
                Debug.Log("Back Right");
                break;
            case Zone.FrontRight:
                _current = frontRight;
                Debug.Log("Front Right");
                break;
        }
        
        AudioSource.PlayClipAtPoint(_current, this.transform.position);
        
    }
}
