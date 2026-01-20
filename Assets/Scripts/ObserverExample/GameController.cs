using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour,ISubject
{
    private static GameController instance;


    public static GameController Instance { get { return instance; } }

    private List<IObserver> observers;
    private int progression;
    private float timer;

    public int Progression { get { return progression; } }

    private void Awake()
    {
        instance = this;
        observers = new List<IObserver>();
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Execute(this);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= progression)
        {
            progression++;
            Notify();
        }
    }
}
