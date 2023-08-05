using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameRunnerCallbacks : MonoBehaviour, INetworkRunnerCallbacks
{

    [SerializeField] private NetworkPrefabRef PlayerPref;
    [SerializeField] private NetworkPlayer networkPlayer;
    private readonly LobbyController LobbyController;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("GameRunnerCallbacks OnPlayerJoined");
        if (runner.IsServer)
        {
            // Create a unique position for the player
            Vector3 spawnPosition = new Vector3((player.RawEncoded % runner.Config.Simulation.DefaultPlayers) * 3, 0, 0);
            NetworkObject networkPlayerObject = runner.Spawn(PlayerPref, spawnPosition, Quaternion.identity, player);
            // Keep track of the player avatars so we can remove it when they disconnect
            FusionManager.Instance.SpawnedCharacters.Add(player, networkPlayerObject);

        }

    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("GameRunnerCallbacks OnPlayerLeft");
        if (FusionManager.Instance.SpawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            FusionManager.Instance.SpawnedCharacters.Remove(player);
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        NetworkInputData data = new NetworkInputData();

        if (Input.GetKey(KeyCode.W))
        {
            data.direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            data.direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            data.direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            data.direction += Vector3.right;
        }
        if (networkPlayer.IsEnableJoyStick)
        {
            data.direction = new Vector3(networkPlayer.joyStickVal.x, 0, networkPlayer.joyStickVal.y);
            //MeshAgent.destination = transform.position + new Vector3(joyStickVal.x, 0, joyStickVal.y);
            //MainCharacter.Move(new Vector3(joyStickVal.x, 0, joyStickVal.y));
        }
        input.Set(data);
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("GameRunnerCallbacks OnSessionListUpdated");
        FusionManager.ON_SESSION_LIST_UPDATED?.Invoke(sessionList);
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }
    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}
