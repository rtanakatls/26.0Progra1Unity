using UnityEngine;

public interface IObserver 
{
    void Execute(ISubject subject);
}
