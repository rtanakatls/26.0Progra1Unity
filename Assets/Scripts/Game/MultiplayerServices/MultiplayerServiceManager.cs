
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Multiplayer;
using UnityEngine;

public class MultiplayerServiceManager : MonoBehaviour
{
    private static MultiplayerServiceManager instance;

    public static MultiplayerServiceManager Instance { get  { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    public async Task InitializeServiceAsync()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async Task<IHostSession> CreateSessionAsync()
    {
        SessionOptions options = new SessionOptions
        {
            MaxPlayers = 4
        }.WithRelayNetwork();
        IHostSession session = await MultiplayerService.Instance.CreateSessionAsync(options);
        return session;
    }

    public async Task<IList<ISessionInfo>> GetSessionAsync()
    {
        QuerySessionsOptions options = new QuerySessionsOptions { };
        QuerySessionsResults result = await MultiplayerService.Instance.QuerySessionsAsync(options);
        return result.Sessions;
    }

    public async Task JoinSessionByIdAsync(string sessionId)
    {
        await MultiplayerService.Instance.JoinSessionByIdAsync(sessionId);
    }


}
