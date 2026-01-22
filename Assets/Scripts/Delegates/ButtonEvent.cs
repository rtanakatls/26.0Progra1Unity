using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private Button b1;
    [SerializeField] private Button b2;
    [SerializeField] private Button b3;
    [SerializeField] private Button b4;


    private Action OnTest;

    private void Start()
    {
        b1.onClick.AddListener(OnButtonClicked1);


        b2.onClick.AddListener(() => { Debug.Log("Button 2 Clicked"); });
        int a = 10;

        b3.onClick.AddListener(() => OnButton3Clicked(a));

        b4.onClick.AddListener(() => OnTest?.Invoke());
    }


    public void SetTest(Action action)
    {
        OnTest = action;
    }

    private void OnButtonClicked1()
    {
        Debug.Log("Button 1 Clicked");
    }

    private void OnButton3Clicked(int a)
    {
        Debug.Log($"Button 3 Clicked with value: {a}");
    }

}
