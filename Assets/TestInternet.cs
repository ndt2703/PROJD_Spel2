using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestInternet : MonoBehaviour
{
    public GameObject gameObjectToDeActivatePlayer1;
    public GameObject gameObjectToActivatePlayer1;
    public GameObject gameObjectToActivatePlayer2;
    public GameObject gameObjectToDeActivatePlayer2;

    public int LocalPlayerNumber; 

    // Start is called before the first frame update
    void Start()
    {
        // System.Threading.Thread.(sendRequest(new ClientRequest()));

        ClientRequest test = new ClientRequest();

        Thread starThread = new Thread(this.sendRequest);

        starThread.Start();
    }



    public void sendRequest(object data)
    {

  //      return null; 
    }
    public ServerResponse sendRequest(ClientRequest data)
    {

        
        return null; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ServerResponse HandleClientRequest(ClientRequest requestToHandle)
    {   
        if(requestToHandle.whichPlayer == 0)
        {
            if(requestToHandle.disableCard)
            {
                gameObjectToActivatePlayer1.SetActive(true);
                gameObjectToDeActivatePlayer1.SetActive(false);
            }
        }        
        if(requestToHandle.whichPlayer == 1)
        {
            if(requestToHandle.disableCard)
            {
                gameObjectToActivatePlayer2.SetActive(true);
                gameObjectToDeActivatePlayer2.SetActive(false);
            }
        }

        return null; 
    }
}
public class ServerResponse
{

}
public class ClientRequest
{
    public int type; 
    public int whichPlayer; 
    public bool disableCard; 
}