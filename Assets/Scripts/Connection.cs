using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkManager))]
public class Connection : MonoBehaviour {
    NetworkManager manager;

    void Start()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void StrtServer()
    {
        manager.StartHost();
    }

    public void CnnctServer()
    {
        manager.StartClient();
    }


}
