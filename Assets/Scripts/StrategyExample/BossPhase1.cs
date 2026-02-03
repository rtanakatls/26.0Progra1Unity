using UnityEngine;

public class BossPhase1 : IBossStrategy
{
    private Rigidbody rb;
    private float speed;

    public BossPhase1(Rigidbody rb, float speed)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public void Execute()
    {
        rb.linearVelocity=Vector3.forward * speed;
    }

    public void End()
    {
        rb.linearVelocity=Vector3.zero;
    }
}
