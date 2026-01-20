using UnityEngine;

public class Manager 
{
    private static Manager instance;

    private string name;

    public string Name 
    { 
        get => name; 
        set => name = value;
    }

    private Manager()
    {

    }

    public static Manager GetInstance()
    {
        if(instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }
}
