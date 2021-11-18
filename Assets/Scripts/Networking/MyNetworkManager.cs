using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [Header("My Variables")]
    [SerializeField] List<GameObject> players;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        var newPlayer = conn.identity.GetComponent<MyNetworkPlayer>();

        newPlayer.SetDisplayName($"Player {numPlayers}");

        var instace = Instantiate(players[numPlayers - 1], conn.identity.transform);

        instace.GetComponent<PlayerCharacter>().parentIdentity = conn.identity;

        NetworkServer.Spawn(instace, conn);

        newPlayer.SetChild(instace.GetComponent<NetworkIdentity>());

        Debug.Log($"Join player {numPlayers} the server!!!!");
    }

    public override void ServerChangeScene(string newSceneName)
    {
        base.ServerChangeScene(newSceneName);
        Debug.Log(newSceneName);
    }
}
