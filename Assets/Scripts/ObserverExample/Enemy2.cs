using UnityEngine;

public class Enemy2 : MonoBehaviour, IObserver
{
    
    private void Start()
    {
        GameController.Instance.Attach(this);
    }

    public void Execute(ISubject subject)
    {
        if (subject is GameController)
        {
            transform.localScale = Vector3.one*((GameController)subject).Progression;
        }
    }

    private void OnDestroy()
    {
        if (GameController.Instance)
        {
            GameController.Instance.Detach(this);
        }
    }
}
