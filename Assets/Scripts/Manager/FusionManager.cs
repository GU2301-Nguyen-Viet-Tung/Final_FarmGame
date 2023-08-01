using Fusion;
using System;
using System.Collections.Generic;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector3 direction;
}

public class FusionManager : ISingleton<FusionManager>
{
    public bool IsInit { get; private set; }
    public static Action<List<SessionInfo>> ON_SESSION_LIST_UPDATED { get; set; }
    public NetworkRunner NetworkRunner { get; private set; }
    public NetworkSceneManagerDefault NetworkSceneManagerDefault { get; private set; }
    public Dictionary<PlayerRef, NetworkObject> SpawnedCharacters { get; private set; } = new Dictionary<PlayerRef, NetworkObject>();
    public FusionManager()
    {
        IsInit = false;
    }
    public void Init(NetworkRunner networkRunner, NetworkSceneManagerDefault networkSceneManagerDefault)
    {
        Debug.Log("FusionManager init");
        NetworkRunner = networkRunner;
        NetworkSceneManagerDefault = networkSceneManagerDefault;
        IsInit = true;
    }

    public async void JoinLobby(string lobbyName)
    {
        await NetworkRunner.JoinSessionLobby(SessionLobby.ClientServer, lobbyName);
    }

    private async void StartGame(GameMode mode, string lobby, string roomName)
    {
        Debug.Log("FusionManager StartGame");
        NetworkRunner.ProvideInput = true;
        NetworkRunner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        StartGameArgs config = new()
        {
            GameMode = mode,
            SessionName = roomName,
            CustomLobbyName = lobby,
            Scene = 4,
            SceneManager = NetworkRunner.gameObject.GetComponent<NetworkSceneManagerDefault>(),
        };

        await NetworkRunner.StartGame(config);

    }

    public void HostAGame(string lobby, string sessionName)
    {
        StartGame(GameMode.Host, lobby, sessionName);
    }

    public void JoinAGame(string lobby, string sessionName)
    {
        StartGame(GameMode.Client, lobby, sessionName);
    }

    public void ExitGame()
    {
        NetworkRunner.Shutdown();
    }
}
