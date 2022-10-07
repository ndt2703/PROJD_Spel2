using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class IpAdressInputField : MonoBehaviour
{
    public TextMeshProUGUI inputField;

    ClientConnection clientConnection;

    TestInternet testInternet;

    bool isHost = false; 
 //   public  inputFieldText; 

    // Start is called before the first frame update
    void Start()
    {
      //  inputField = GetComponent<InputField>();

        clientConnection = FindObjectOfType<ClientConnection>();

        testInternet = FindObjectOfType<TestInternet>();
        
    }

    public void CreateScene(ServerResponse response)
    {
        print("Creater den sccene");
        testInternet.CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            clientConnection.ConnectToServer("193.10.9.96", 60000);

         

            ClientRequest request = new ClientRequest();
            if(clientConnection.isHost)
            {
                request.whichPlayer = 0;
                clientConnection.playerId = 0; 
            }
            else
            {
                request.whichPlayer = 1;
                clientConnection.playerId = 1;
            }
            request.createScene = true;

            clientConnection.AddRequest(request, CreateScene);
            testInternet.hasJoinedLobby = true;
            print("keypad entererar den");

            print("vilken player id har man  " + ClientConnection.Instance.playerId); 
        }
    }
}
