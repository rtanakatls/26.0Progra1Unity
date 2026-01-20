using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int a = 10;


        Controller c = new Controller();
        c.Name = "TestName";

        Controller c2 = new Controller();
        c2.Name = "AnotherName";

        Debug.Log($"{c.Name}");
        Debug.Log($"{c2.Name}");


        Manager m = Manager.GetInstance();
        m.Name = "TestName";

        Manager m2=Manager.GetInstance();
        m2.Name = "AnotherName";

        Debug.Log($"{m.Name}");
        Debug.Log($"{m2.Name}");
    }

}
