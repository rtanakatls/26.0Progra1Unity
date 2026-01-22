using UnityEngine;

public class TestCallback : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Event>().OnTest += Execute;    
    }

    private void Execute()
    {
        Debug.Log("Llamando acá");
    }
}
