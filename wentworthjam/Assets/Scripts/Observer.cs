using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
  public abstract void OnNotify(object value, Zone zoneType);
}

public abstract class Subject : MonoBehaviour
{
  private List<Observer> _observers = new List<Observer>();

  public void RegisterObserver(Observer observer)
  {
    _observers.Add(observer);
  }

  public void Notify(object value, Zone zoneType)
  {
    foreach (var observer in _observers)
    {
      observer.OnNotify(value, zoneType);
    }
  }
  
}

public enum Zone {FrontLeft , FrontRight, BackLeft, BackRight}
