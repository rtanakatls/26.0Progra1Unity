using UnityEngine;
using UnityEngine.UI;

public class MultiplayerLeaveUI : MonoBehaviour
{
    [SerializeField] private GameObject multiplayerCanvas;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(Leave);
    }

    private async void Leave()
    {
        await MultiplayerServiceManager.Instance.LeaveSessionAsync();
        Instantiate(multiplayerCanvas);
         
    }

}
