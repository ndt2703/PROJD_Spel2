using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class TestCallback : MonoBehaviour
{


    public void damageTest()
    {

        
        Tuple<TargetInfo, int> testTuple = new Tuple<TargetInfo, int>(new TargetInfo(), 10);
        List<Tuple<TargetInfo, int>> testList = new List<Tuple<TargetInfo, int>>();
        testList.Add(testTuple);
        RequestDamage testRequest = new RequestDamage(testList);
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    

    public void healTest()
    {

        
        Tuple<TargetInfo, int> testTuple = new Tuple<TargetInfo, int>(new TargetInfo(), 10);
        List<Tuple<TargetInfo, int>> testList = new List<Tuple<TargetInfo, int>>();
        testList.Add(testTuple);
        RequestHealing testRequest = new RequestHealing(testList);
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }  

    public void shieldTest()
    {

        
        Tuple<TargetInfo, int> testTuple = new Tuple<TargetInfo, int>(new TargetInfo(), 10);
        List<Tuple<TargetInfo, int>> testList = new List<Tuple<TargetInfo, int>>();
        testList.Add(testTuple);
        RequestShield testRequest = new RequestShield(testList);
        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void discardTest()
    {
        List<String> testList = new List<string>();
        RequestDiscardCard requestDiscard = new RequestDiscardCard(testList);
        

        ClientConnection.Instance.AddRequest(requestDiscard, DummyCallback);
    }

    
    public void switchActiveChampTest()
    {
        Tuple<TargetInfo,TargetInfo> testList = new Tuple<TargetInfo,TargetInfo>(new TargetInfo(),new TargetInfo());
        RequestSwitchActiveChamps testRequest = new RequestSwitchActiveChamps(testList);
        

        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    
    
    public void removeCardsFromGraveyardTest()
    {
        List<TargetInfo> testList = new List<TargetInfo>();
        RequestRemoveCardsGraveyard testRequest = new RequestRemoveCardsGraveyard(testList);
        

        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void playCardTest()
    {
        Tuple<string,TargetInfo> testList = new Tuple<string,TargetInfo>("", new TargetInfo());
        RequestPlayCard testRequest = new RequestPlayCard(testList);
        

        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }
    public void addSpecificCardToHandTest()
    {
        string cardToAdd = "";
        
        RequestAddSpecificCardToHand testRequest = new RequestAddSpecificCardToHand(cardToAdd);
        print("vilken typ har testRequest " + testRequest.Type + " " + testRequest.GetType());  

        ClientConnection.Instance.AddRequest(testRequest, DummyCallback);
    }




    public void DummyCallback(ServerResponse response)
    {

    }
}
