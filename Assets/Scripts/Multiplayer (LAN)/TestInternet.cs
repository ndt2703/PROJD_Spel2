using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestInternet : MonoBehaviour
{
    public GameObject gameObjectToDeActivatePlayer1;
    public GameObject gameObjectToActivatePlayer1;
    public GameObject gameObjectToActivatePlayer2;
    public GameObject gameObjectToDeActivatePlayer2;

   private Scene gameplayScene;

    ClientConnection clientConnection;

    [SerializeField] private string loadScene;
    bool hasEstablishedEnemurator = false; 


    public Dictionary<int, GameObject> cards  = new Dictionary<int, GameObject>();

    public GameObject cardToPlay;
   public  bool hasJoinedLobby = false;
    //   public int LocalPlayerNumber; 

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        cards.Add(1, cardToPlay);
        // System.Threading.Thread.(sendRequest(new ClientRequest()));

        clientConnection = ClientConnection.Instance;
        
    }


    public void PerformOpponentsActions(ServerResponse response)
    {

        foreach (GameAction action in response.OpponentActions)
        {
            
            if(action.cardPlayed)
            {
                //print("Skiter det sig i perform oppnent action " + action.cardId);
                PlayCard(action.cardId);

                Destroy(GameObject.Find("Card (1)"));
            }


            if (action.GetType(action.Type).Equals(typeof(GameActionEndTurn)) )
            {
               // print("skickar den en gameAction end turn");
                GameState.Instance.SwitchTurn(response);

                GameState.Instance.hasPriority = true;

            }
            print("Vilken type har actionen" + action.Type);
            if (action.GetType(action.Type).Equals(typeof(GameActionEndTurn)))
            {
                print("skickar den en gameAction draw card");
                GameActionDrawCard theAction = (GameActionDrawCard)action;
                
            //    if(theAction.amountToDrawOpponent >0)
            //    {
            //        GameLoop.Instance.DrawCard(2); 
            //    }
                GameLoop.Instance.DrawCard(2);

            }



            //Discard game action

            //Remove card from graveyard 

            // heal game action
            // shield game action
            //add specific card to hand action bn

            //Switch active champion action

            //destroy landmark game action 

            if (!action.errorMessage.Equals("") /*&& !action.errorMessage == null*/)
            {
                print(action.errorMessage); 
            }
        }
    }

    public void PlayCardCallback(ServerResponse response)
    {
        PlayCard(response.cardId);
    }

    public void PlayCard(int cardId)
    {

        Instantiate(cards[cardId], GameObject.Find("CardHolder").transform); //WIP
       
    }

    public void CreateScene()
    {
        SceneManager.LoadScene(loadScene);
    }

//    public void playCard(ServerResponse response)
//    {
//        if (!response.cardPlayed)
//        {
//            return;
//        }
//        if (response.whichPlayer == 0)
//        {
//            gameObjectToDeActivatePlayer1.SetActive(false);
//            gameObjectToActivatePlayer1.SetActive(true);
//        }
//        else
//        { 
//            gameObjectToActivatePlayer2.SetActive(true);
//            gameObjectToDeActivatePlayer2.SetActive(false);
//        }
//    }


    // Update is called once per frame
    void FixedUpdate()
    {   if(hasJoinedLobby && !hasEstablishedEnemurator)
        {                        //InvokeRepeating(nameof(SendRequest), 0, 1);
                                 // hasEstablishedEnemurator = true;
                                 // 
                                 StartCoroutine(SendRequest());
                                 //    hasEstablishedEnemurator = true;
                                 //    

        

            /*if (waitTime < 0)
            {
                waitTime = 60;
                RequestOpponentActions request = new RequestOpponentActions(ClientConnection.Instance.playerId, true);

                clientConnection.AddRequest(request, PerformOpponentsActions);

            }*/
        }
        print("Vilken spelar id har man " + clientConnection.playerId);
    }
    

    private IEnumerator SendRequest()
    {
        //
        //            ClientRequest request = new ClientRequest();
        //
        //            request.isPolling = true;
        //
        //            request.whichPlayer = clientConnection.playerId;
        //
        //            clientConnection.AddRequest(request, playCard);

        RequestOpponentActions request = new RequestOpponentActions(ClientConnection.Instance.playerId, true);

        clientConnection.AddRequest(request, PerformOpponentsActions);
       
        yield return new WaitForSeconds(0);
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