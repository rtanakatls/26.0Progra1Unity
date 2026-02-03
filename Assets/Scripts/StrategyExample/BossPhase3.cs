using UnityEngine;

public class BossPhase3 : MonoBehaviour
{

    [SerializeField] float a = 0.001f;
    [SerializeField] float b = 0.002f;

    void Start()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start2()
    {
        Vector3 a;
        a = Vector3.zero;
        Debug.Log($"Vector3.zero: {a}");
        a = Vector3.up;
        Debug.Log($"Vector3.up: {a}");
        a = Vector3.forward;
        Debug.Log($"Vector3.forward: {a}");
        a = Vector3.right;
        Debug.Log($"Vector3.right: {a}");
        a = Vector3.left;
        Debug.Log($"Vector3.left: {a}");
        a = Vector3.down;
        Debug.Log($"Vector3.down: {a}");
        a = Vector3.back;
        Debug.Log($"Vector3.back: {a}");
        a = Vector3.one;
        Debug.Log($"Vector3.one: {a}");
        a = Vector3.positiveInfinity;
        Debug.Log($"Vector3.positiveInfinity: {a}");
        a = Vector3.negativeInfinity;
        Debug.Log($"Vector3.negativeInfinity: {a}");

        

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(a + b);
        //Debug.Log($"transform.forward: {transform.forward}");

    }
}
