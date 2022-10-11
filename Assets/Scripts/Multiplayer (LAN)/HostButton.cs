using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostButton : MonoBehaviour
{
    // public Server server = new Server(); 
    ClientConnection clientConnection;
    // Start is called before the first frame update
    void Start()
    {
        clientConnection = FindObjectOfType<ClientConnection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HostServer()
    {

        print("Hostar den flera gangar");
        FindObjectOfType<ServerHolder>().StartServer();

        clientConnection.isHost = true; 
    }
}
