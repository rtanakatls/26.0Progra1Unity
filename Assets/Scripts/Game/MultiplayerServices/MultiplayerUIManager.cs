using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Multiplayer;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject joinButtonPrefab;
    [SerializeField] private GameObject joinButtonContainer;

    [SerializeField] private Button refreshButton;
    [SerializeField] private Button hostButton;

    private void Awake()
    {
        refreshButton.onClick.AddListener(Refresh);
        hostButton.onClick.AddListener(Host);
    }

    private async void Start()
    {
        await MultiplayerServiceManager.Instance.InitializeServiceAsync();
    }

    private async void Host()
    {
        try
        {
            LoadingScreen.Instance.Show();
            await MultiplayerServiceManager.Instance.CreateSessionAsync();
            Destroy(canvas);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        LoadingScreen.Instance.Hide();
    }

    private async void Refresh()
    {
        try
        {
            LoadingScreen.Instance.Show();
            foreach (Transform t in joinButtonContainer.GetComponentInChildren<Transform>())
            {
                if (t != joinButtonContainer.transform)
                {
                    Destroy(t.gameObject);
                }
            }

            IList<ISessionInfo> sessions = await MultiplayerServiceManager.Instance.GetSessionAsync();

            if (sessions.Count > 0)
            {
                foreach (ISessionInfo session in sessions)
                {
                    GameObject obj = Instantiate(joinButtonPrefab, joinButtonContainer.transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = $"Join {session.Id} - {session.AvailableSlots}/{session.MaxPlayers}";
                    obj.GetComponent<Button>().onClick.AddListener(() => Join(session.Id));
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        LoadingScreen.Instance.Hide();
    }

    public async void Join(string sessionId)
    {
        try
        {
            LoadingScreen.Instance.Show();
            await MultiplayerServiceManager.Instance.JoinSessionByIdAsync(sessionId);
            Destroy(canvas);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        LoadingScreen.Instance.Hide();
    }

}
