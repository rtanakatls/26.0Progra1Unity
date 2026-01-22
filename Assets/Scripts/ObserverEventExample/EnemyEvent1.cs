using UnityEngine;

public class EnemyEvent1 : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameEventController.Instance.OnProgressionChanged += OnProgressionChanged;
    }

    public void OnProgressionChanged(int progression)
    {
        speed= progression;
    }

    private void Update()
    {
        rb.linearVelocity = Vector3.forward * speed;
    }

    private void OnDestroy()
    {
        if (GameEventController.Instance)
        {
            GameEventController.Instance.OnProgressionChanged -= OnProgressionChanged;
        }
    }
}
