
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

    private ISession currentSession;

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
        
        currentSession = session;
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
        currentSession = await MultiplayerService.Instance.JoinSessionByIdAsync(sessionId);

    }

    public async Task LeaveSessionAsync()
    {
        if (currentSession != null)
        {
            await currentSession.LeaveAsync();
            currentSession = null;
        }
    }




}
