using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkData : NetworkBehaviour
{
    [SerializeField] static List<string> playerNames = new List<string>();

    #region Server
    [Command]
    public void CmdSetNewPlayuerName(string newName)
    {
        playerNames.Add(newName);
    }
    #endregion

    #region Client
    #endregion
}
