using UnityEngine;

public class TestEvent : MonoBehaviour
{

    [SerializeField] private int value;

    private void Awake()
    {
        GetComponent<ButtonEvent>().SetTest(OnCallback);
    }

    private void OnCallback()
    {
        Debug.Log($"Llamada a este método con valor {value}");
    }
}
