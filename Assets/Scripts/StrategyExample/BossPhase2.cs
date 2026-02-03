using UnityEngine;

public class BossPhase2 : IBossStrategy
{
    private Rigidbody rb;
    private Transform transform;
    private float timer;

    public BossPhase2(Transform transform,Rigidbody rb)
    {
        this.rb = rb;
        this.transform = transform;
        rb.useGravity = false;
    }

    public void Execute()
    {
        transform.localScale = Vector3.one * (1+Mathf.PingPong(timer, 1));
        timer += Time.deltaTime;
    }

    public void End()
    {
        transform.localScale = Vector3.one;
        rb.useGravity = true;
    }
}
