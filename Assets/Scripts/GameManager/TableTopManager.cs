using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class TableTopManager : NetworkBehaviour
{
    [SerializeField] Button botonCambioEscena;

    [ServerCallback]
    private void Start()
    {
        botonCambioEscena.onClick.AddListener(ChangeScene);
    }

    [Server]
    public void ChangeScene()
    {
        NetworkManager.singleton.ServerChangeScene("ThirdScene");
    }
}
