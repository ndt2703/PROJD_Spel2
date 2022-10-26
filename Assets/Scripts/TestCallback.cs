using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class TestCallback : MonoBehaviour
{


    public void damageTest()
    {


    }
    

    public void healTest()
    {


    }  

    public void shieldTest()
    {

    }
    public void discardTest()
    {
        List<String> testList = new List<string>();
        RequestDiscardCard requestDiscard = new RequestDiscardCard(testList);

        requestDiscard.whichPlayer = ClientConnection.Instance.playerId;
        ClientConnection.Instance.AddRequest(requestDiscard, DummyCallback);
    }

    
    public void switchActiveChampTest()
    {
        Tuple<TargetInfo,TargetInfo> testList = new Tuple<TargetInfo,TargetInfo>(new TargetInfo(),new TargetInfo());
        RequestSwitchActiveChamps testRequest = new RequestSwitchActiveChamps(testList);

        testRequest.whichPlayer = ClientConnection.Instance.playerId;
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    
    
    public void removeCardsFromGraveyardTest()
    {
        List<TargetInfo> testList = new List<TargetInfo>();
        RequestRemoveCardsGraveyard testRequest = new RequestRemoveCardsGraveyard(testList);

        testRequest.whichPlayer = ClientConnection.Instance.playerId;
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void destroyLandmarkTest()
    {
        List<TargetInfo> testList = new List<TargetInfo>();
        RequestDestroyLandmark testRequest = new RequestDestroyLandmark(testList);

        testRequest.whichPlayer = ClientConnection.Instance.playerId;
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void playCardTest()
    {
    //    Tuple<string,TargetInfo> testList = new Tuple<string,TargetInfo>("", new TargetInfo());
    //    RequestPlayCard testRequest = new RequestPlayCard(testList);
    //
    //    testRequest.whichPlayer = ClientConnection.Instance.playerId;
    //    ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void addSpecificCardToHandTest()
    {
        string cardToAdd = "";
        
        RequestAddSpecificCardToHand testRequest = new RequestAddSpecificCardToHand(cardToAdd);
        print("vilken typ har testRequest " + testRequest.Type + " " + testRequest.GetType());
        testRequest.whichPlayer = ClientConnection.Instance.playerId;
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }




    public void DummyCallback(ServerResponse response)
    {

    }
}
