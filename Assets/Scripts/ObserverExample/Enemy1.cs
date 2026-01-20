using UnityEngine;

public class Enemy1 : MonoBehaviour,IObserver
{
    private Rigidbody rb;
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameController.Instance.Attach(this);
    }

    public void Execute(ISubject subject)
    {
        if(subject is GameController)
        {
            speed = ((GameController)subject).Progression;
        }
    }

    private void Update()
    {
        rb.linearVelocity = Vector3.forward * speed;
    }

    private void OnDestroy()
    {
        if (GameController.Instance)
        {
            GameController.Instance.Detach(this);
        }
    }
}
