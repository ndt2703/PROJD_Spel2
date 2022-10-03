using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonServerCall : MonoBehaviour
{
    public ClientConnection connection;
    public TestInternet testInternet;
    // Start is called before the first frame update
    void Start()
    {
        connection = FindObjectOfType<ClientConnection>();
        testInternet = FindObjectOfType<TestInternet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallTestInternet(ServerResponse response)
    {
        if (response.cardPlayed)
        {
            testInternet.playCard(response);
        }
    }

    public void playCardOnBoard()
    {
        ClientRequest request = new ClientRequest();

        request.whichPlayer = connection.playerId;

        request.isPolling = true;

        request.hasPlayedCard = true;

        connection.AddRequest(request,CallTestInternet);

    }
}
