using UnityEngine;

public class RotateObject : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(-Vector3.forward * 360 * Time.deltaTime);
    }
}
