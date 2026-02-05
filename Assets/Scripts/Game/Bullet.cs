using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    private Vector3 direction;
    private Rigidbody rb;
    [SerializeField] private float speed;
    private ulong ownerId;

    public void SetUp(Vector3 direction, ulong ownerId)
    {
        this.direction = direction.normalized;
        this.ownerId = ownerId;
    }

    private void Start()
    {
        if (!IsServer)
        {
            return;
        }

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsServer)
        {
            return;
        }
        rb.linearVelocity= direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!IsServer)
        {
            return;
        }

        if (other.gameObject.CompareTag("Player") && other.GetComponent<Player>().OwnerClientId != ownerId)
        {
            NetworkObject.Despawn();
        }
    }
}
