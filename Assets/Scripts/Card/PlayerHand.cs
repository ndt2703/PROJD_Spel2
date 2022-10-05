using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private List<GameObject> hand = new List<GameObject>();
    private TestInternet testInternet;

    private void Start()
    {
        testInternet = FindObjectOfType<TestInternet>();

       hand.Add(GameObject.Find("Card"));
    }

    public void PlayCard(GameObject card)
    {
        hand.Remove(card);

        ClientRequest request = new ClientRequest();
        request.cardId = 1;
        request.hasPlayedCard = true;

        FindObjectOfType<ClientConnection>().AddRequest(request, testInternet.PlayCardCallback);
    }

}
