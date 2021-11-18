using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCharacter : NetworkBehaviour
{
    [SyncVar]
    public NetworkIdentity parentIdentity;

    public override void OnStartClient()
    {
        base.OnStartClient();
        transform.SetParent(parentIdentity.transform);
    }
}
