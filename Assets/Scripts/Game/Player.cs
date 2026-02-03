using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    private InputSystem_Actions input;
    private InputAction moveAction;
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb=GetComponent<Rigidbody>();
        input = new InputSystem_Actions();
        moveAction = input.Player.Move;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        Vector2 direction= moveAction.ReadValue<Vector2>();
        rb.linearVelocity=direction*speed;
    }
}
