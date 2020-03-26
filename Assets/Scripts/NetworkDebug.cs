using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class NetworkDebug : NetworkBehaviour
{
    // Start is called before the first frame update
    void OnGUI()
    {
        string ipadress = NetworkClient.serverIp;
        GUI.Box(new Rect(10, Screen.height - 75, 100, 50), "isLocalPlayer: " + isLocalPlayer);
        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipadress);
        GUI.Label(new Rect(20, Screen.height - 35, 100, 20), "Status: " + NetworkServer.active);
        GUI.Label(new Rect(20, Screen.height - 20, 100, 20), "Connected: " + NetworkServer.connections.Count);
    }
    // Use this for initialization
}
