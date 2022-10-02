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
        testInternet.CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            clientConnection.ConnectToServer(inputField.text, 60000);

            clientConnection.playerId = 1;

            ClientRequest request = new ClientRequest();
            request.whichPlayer = clientConnection.playerId;
            request.createScene = true;

            clientConnection.AddRequest(request, CreateScene);

            print("keypad entererar den");
        }
    }
}
