using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [Header("My Variables")]
    [SerializeField] List<GameObject> players;

    [SerializeField] TMP_InputField field;

    [SerializeField] List<string> playerNames = new List<string>();
    [SerializeField] List<int> coins = new List<int>();

    public void AddCoins(int coinsToAdd, int index)
    {
        coins[index] += coinsToAdd;
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log($"Se agrega juagdor {conn.connectionId}");

        var newPlayer = conn.identity.GetComponent<MyNetworkPlayer>();

        newPlayer.SetDisplayName($"Player {numPlayers}");
        playerNames.Add($"Player {numPlayers}");
        coins.Add(10);

        var instace = Instantiate(players[numPlayers - 1], conn.identity.transform);

        instace.GetComponent<PlayerCharacter>().parentIdentity = conn.identity;

        NetworkServer.Spawn(instace, conn);

        newPlayer.SetChild(instace.GetComponent<NetworkIdentity>());
    }
}
