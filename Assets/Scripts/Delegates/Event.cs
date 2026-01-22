using System;
using UnityEngine;

public class Event : MonoBehaviour
{
    public event Action OnTest;


    private void Start()
    {
        OnTest += Execute;
    }

    private void Execute()
    {
        Debug.Log("Hola");
    }

    private void Update()
    {
        OnTest?.Invoke();
    }
}
