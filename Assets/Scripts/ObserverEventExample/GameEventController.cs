using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventController : MonoBehaviour
{
    private static GameEventController instance;

    public static GameEventController Instance { get { return instance; } }

    public event Action<int> OnProgressionChanged;

    private int progression;
    private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= progression)
        {
            progression++;
            OnProgressionChanged?.Invoke(progression);
        }
    }
}
