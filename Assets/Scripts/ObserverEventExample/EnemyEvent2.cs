using UnityEngine;

public class EnemyEvent2 : MonoBehaviour
{
    private void Start()
    {
        GameEventController.Instance.OnProgressionChanged += OnProgressionChanged;
    }

    public void OnProgressionChanged(int progression)
    {
        transform.localScale = Vector3.one * progression;
    }

    private void OnDestroy()
    {
        if (GameEventController.Instance)
        {
            GameEventController.Instance.OnProgressionChanged-=OnProgressionChanged;
        }
    }
}
