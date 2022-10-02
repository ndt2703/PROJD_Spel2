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

    public GameObject sceneToActivate;

    ClientConnection clientConnection;
 //   public int LocalPlayerNumber; 

    // Start is called before the first frame update
    void Start()
    {
        // System.Threading.Thread.(sendRequest(new ClientRequest()));

        clientConnection = FindObjectOfType<ClientConnection>();
    }


    public void CreateScene()
    {
        if (clientConnection.playerId == 0)
        {
            gameObjectToDeActivatePlayer1.SetActive(true);
        }
        else
        {
            gameObjectToDeActivatePlayer2.SetActive(true);
        }
    }

    public void playCard(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            gameObjectToDeActivatePlayer1.SetActive(false);
            gameObjectToActivatePlayer1.SetActive(true);
        }
        else
        { 
            gameObjectToActivatePlayer2.SetActive(true);
            gameObjectToDeActivatePlayer2.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}



// public class ServerResponse
// {
// 
// }
// public class ClientRequest
// {
//     public int type;
//     public int whichPlayer;
//     public bool disableCard;
// }