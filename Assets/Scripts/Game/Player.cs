using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Collections;
using Unity.Cinemachine;

public class Player : NetworkBehaviour
{
    private CinemachineCamera virtualCamera;
    private NetworkVariable<FixedString32Bytes> playerName = new NetworkVariable<FixedString32Bytes>();
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private Material ownerMaterial;
    [SerializeField] private Material otherMaterial;
    private InputSystem_Actions input;
    private InputAction moveAction;
    private InputAction attackAction;
    [SerializeField] private float speed;
    private Rigidbody rb;


    [SerializeField] private GameObject bulletPrefab;
    private Vector3 direction;


    private void Awake()
    {
        rb=GetComponent<Rigidbody>();
        input = new InputSystem_Actions();
        moveAction = input.Player.Move;
        attackAction = input.Player.Attack;
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
            virtualCamera = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();

            if (virtualCamera != null)
            {
                virtualCamera.Follow = transform;
            }
        }
        else
        {
            GetComponent<Renderer>().material = otherMaterial;
        }

    }

    private void OnEnable()
    {
        moveAction.Enable();
        attackAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        attackAction.Disable();
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        Vector2 moveInput= moveAction.ReadValue<Vector2>();
        Vector3 direction=new Vector3(moveInput.x,0,moveInput.y);

        if(moveInput.x!=0 || moveInput.y!=0)
        {
            this.direction= direction.normalized;
        }

        if(attackAction.WasPerformedThisFrame())
        {
            ShootRpc(this.direction, transform.position);
        }
        Vector3 velocity= direction * speed+new Vector3(0,rb.linearVelocity.y,0);
        rb.linearVelocity=velocity;
    }

    [Rpc(SendTo.Server)]
    private void ShootRpc(Vector3 direction, Vector3 position)
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = position;
        obj.GetComponent<Bullet>().SetUp(direction, OwnerClientId);
        obj.GetComponent<NetworkObject>().Spawn();
    }

}
