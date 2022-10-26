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



    public GameState gameState;
    public CardRegister register;

   public  bool hasJoinedLobby = false;
    //   public int LocalPlayerNumber; 

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

        // System.Threading.Thread.(sendRequest(new ClientRequest()));

        clientConnection = ClientConnection.Instance;
        
    }


    public void PerformOpponentsActions(ServerResponse response)
    {   
        gameState = GameState.Instance;
        register = CardRegister.Instance;

        foreach (GameAction action in response.OpponentActions)
        {
            
            if(action.cardPlayed)
            {
                //print("Skiter det sig i perform oppnent action " + action.cardId);
                PlayCard(action.cardId);

                Destroy(GameObject.Find("Card (1)"));
            }

            print("vilket object typ ar grejen " + action.GetType());
            if (action is GameActionEndTurn )
            {
                // print("skickar den en gameAction end turn");
                gameState.EndTurn();

            }

            if (action is GameActionDrawCard)
            {
                print("skickar den en gameAction draw card");
                GameActionDrawCard theAction = (GameActionDrawCard)action;
                
                if(theAction.amountToDrawOpponent > 0)
                {
                    gameState.DrawCard(theAction.amountToDrawOpponent, null); 
                }
                if(theAction.amountToDraw > 0)
                {
                    StartCoroutine(gameState.DrawCardOpponent(theAction.amountToDraw,null));

                }
                //Draw card opponents

            }
            if (action is GameActionDiscardCard)
            {
                print("skickar den en gameAction discard");




                GameActionDiscardCard theAction = (GameActionDiscardCard)action;



                foreach(string card in theAction.listOfCardsDiscarded)
                {
                    Graveyard.Instance.AddCardToGraveyard(register.cardRegister[card]);
                    gameState.actionOfPlayer.handOpponent.cardsInHand[0].GetComponent<CardDisplay>().card = null;

                }

                //gameState.DiscardCard(theAction.listOfCardsDiscarded);
                //Draw card opponents

            }
            if (action  is GameActionHeal)
            {
                print("skickar den en gameAction heal");
                //GameActionHeal theAction = (GameActionHeal)action;

                //gameState.Heal(theAction.targetsToHeal);
                //Draw card opponents

            }
            if (action is GameActionDamage)
            {


                print("skickar den en gameAction damage");
                //GameActionDamage theAction = (GameActionDamage)action;

                //Draw card opponents

            }            
            if (action  is GameActionShield)
            {
                print("skickar den en gameAction Shield");
                //GameActionDamage theAction = (GameActionDamage)action;

                //Draw card opponents

            }            
            if (action  is GameActionSwitchActiveChamp)
            {
                print("skickar den en gameAction switch active champion");
                //GameActionSwitchActiveChamp theAction = (GameActionSwitchActiveChamp)action;

                //Draw card opponents

            }            
            if (action is GameActionDestroyLandmark)
            {
                print("skickar den en gameAction destroylandmark");
                //GameActionDestroyLandmark theAction = (GameActionDestroyLandmark)action;

                //Draw card opponents

            }            
            if (action is GameActionRemoveCardsGraveyard)
            {
                print("skickar den en gameAction remove card graveyard");
                //GameActionRemoveCardsGraveyard theAction = (GameActionRemoveCardsGraveyard)action;

                //Draw card opponents

            }            
            if (action  is GameActionPlayCard)
            {
                print("skickar den en gameAction play card");


                GameActionPlayCard castedAction = (GameActionPlayCard)action;

                print("ar register null " + register);

                Card cardPlayed = register.cardRegister[castedAction.cardAndPlacement.cardName];

                if (castedAction.cardAndPlacement.placement.whichList.myGraveyard)
                {
                    Graveyard.Instance.graveyardPlayer.Add(cardPlayed);
                }

                Graveyard.Instance.graveyardPlayer.Add(cardPlayed);

                gameState.actionOfPlayer.handOpponent.cardsInHand[0].GetComponent<CardDisplay>().card = null;
                //bool test =  gameState.actionOfPlayer.handOpponent.cardsInHand.Remove(gameState.actionOfPlayer.handOpponent.cardsInHand[0]);


                //print("tog den bort kort fran handen " + test);
                //GameActionPlayCard theAction = (GameActionPlayCard)action;

                //Draw card opponents

            }    
            if (action  is GameActionOpponentDiscardCard)
            {   

                print("Game action opponent discard card");

                GameActionOpponentDiscardCard castedAction = (GameActionOpponentDiscardCard)action;
                List<string> discardedCards = new List<string>();
                for(int i = 0; i < castedAction.amountOfCardsToDiscard; i++)
                {
                    discardedCards.Add(gameState.DiscardWhichCard(true));
                }

                RequestDiscardCard discardCardRequest = new RequestDiscardCard(discardedCards);
                discardCardRequest.whichPlayer = ClientConnection.Instance.playerId;
                print("vad ar which player " + discardCardRequest.whichPlayer);
                ClientConnection.Instance.AddRequest(discardCardRequest, gameState.RequestDiscardCard);

                //bool test =  gameState.actionOfPlayer.handOpponent.cardsInHand.Remove(gameState.actionOfPlayer.handOpponent.cardsInHand[0]);


                //print("tog den bort kort fran handen " + test);
                //GameActionPlayCard theAction = (GameActionPlayCard)action;

                //Draw card opponents

            }
           
            if (action.GetType(action.Type).Equals(typeof(GameActionAddSpecificCardToHand)))
            {
                print("skickar den en gameAction add specific card");
               // GameActionAddSpecificCardToHand theAction = (GameActionAddSpecificCardToHand)action;

                //Draw card opponents

            }

            







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

      //  Instantiate(cards[cardId], GameObject.Find("CardHolder").transform); //WIP
       
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