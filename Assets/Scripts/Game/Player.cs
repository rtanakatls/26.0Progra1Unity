using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Collections;

public class Player : NetworkBehaviour
{

    private NetworkVariable<FixedString32Bytes> playerName = new NetworkVariable<FixedString32Bytes>();
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private Material ownerMaterial;
    [SerializeField] private Material otherMaterial;
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

    public override void OnNetworkSpawn()
    {
        nameText.text= playerName.Value.ToString();
        playerName.OnValueChanged += (oldName, newName) =>
        {
            nameText.text = newName.ToString();
        };
    }

    public void SetName(string name)
    {
        if (!IsOwner)
        {
            return;
        }
        SendNameToServerRpc(name);

    }

    [Rpc(SendTo.Server)]
    private void SendNameToServerRpc(string name)
    {
        playerName.Value = name;
        SendNameToClientsRpc(name);
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void SendNameToClientsRpc(string name)
    {
        nameText.text = name;   
    }

    private void Start()
    {
        if (IsOwner)
        {
            GetComponent<Renderer>().material = ownerMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = otherMaterial;
        }
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

        Vector2 moveInput= moveAction.ReadValue<Vector2>();
        Vector3 direction=new Vector3(moveInput.x,0,moveInput.y);
        Vector3 velocity= direction * speed+new Vector3(0,rb.linearVelocity.y,0);
        rb.linearVelocity=velocity;
    }
}
