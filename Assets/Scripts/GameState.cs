using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class GameState : MonoBehaviour
{
    public int currentPlayerID = 0;
    public bool hasPriority = true;

    public bool isPlayerOnesTurn;
    public bool playerOneStarted;

    public int amountOfTurns;

    private ActionOfPlayer actionOfPlayer;

    [SerializeField] private int amountOfCardsToStartWith = 5;


    public int playerOneMana;
    public int playerTwoMana;
    public int maxMana = 10;
    public int currentMana;
    public SpriteRenderer playedCardSpriteRenderer;

    public Champion playerChampion;
    public Champion opponentChampion;

    public List<Champion> playerChampions = new List<Champion>();
    public List<Champion> opponentChampions = new List<Champion>();

    public List<Landmarks> playerLandmarks = new List<Landmarks>();
    public List<Landmarks> opponentLandmarks = new List<Landmarks>();



    private static GameState instance;
    public static GameState Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        List<Champion> championsTemp = new List<Champion>();
        AvailableChampion[] aC = GameObject.Find("PlayerChampions").GetComponentsInChildren<AvailableChampion>();
		for (int i = 0; i < playerChampions.Count; i++)
        {
            Champion champ = (Champion)ScriptableObject.CreateInstance(playerChampions[i].name);
            champ.name = playerChampions[i].name;
            championsTemp.Add(champ);
            aC[i].champion = champ;
        }
        playerChampions = championsTemp;
        playerChampion = championsTemp[0];
        
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        actionOfPlayer = ActionOfPlayer.Instance;

        int random = UnityEngine.Random.Range(0, 2);
        if (random == 1)
        {
            playerOneStarted = true;
            isPlayerOnesTurn = true;
        }

        else if (random == 0)
        {
            playerOneStarted = false;
            isPlayerOnesTurn = false;
        }


        Invoke(nameof(DrawStartingCards), 0.01f);
    }
    private void DrawStartingCards()
    {
        DrawCard(amountOfCardsToStartWith);
    }

    public void DiscardCard()
    {
        actionOfPlayer.handPlayer.DiscardRandomCardInHand();
    }

    public void DrawCardRequest(ServerResponse response)
    {
        ResponseDrawCard castedReponse = (ResponseDrawCard)response;

        DrawCard(castedReponse.amountToDraw);
    }

    public void DrawCard(int amountToDraw)
    {
		StartCoroutine(DrawCardPlayer(amountToDraw));
	}

    public bool LegalEndTurn()
    {
        if(hasPriority && currentPlayerID == ClientConnection.Instance.playerId)
        {
            return true;
        }
        return false;
    }

    public void ShowPlayedCard(Card card)
    {
        playedCardSpriteRenderer.sprite = card.artwork;
        Invoke(nameof(HideCardPlayed), 1.5f);
    }
    private void HideCardPlayed()
    {
        playedCardSpriteRenderer.sprite = null;
    }




    private IEnumerator DrawCardPlayer(int amountToDraw)
    {
        if (actionOfPlayer.handPlayer.cardsInHand.Count > 0)
        {
            ChangeCardOrder();
            yield return new WaitForSeconds(0.01f); 
        }

        int drawnCards = 0;
        foreach (GameObject cardSlot in actionOfPlayer.handPlayer.cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null) continue;

            if (!cardSlot.activeSelf)
            {
                if (drawnCards >= amountToDraw) break;

                cardDisplay.card = actionOfPlayer.handPlayer.deck.WhichCardToDraw();
                cardSlot.SetActive(true);
                drawnCards++;
            }
        }

    }

    private void ChangeCardOrder()
    {
        Hand hand = actionOfPlayer.handPlayer;
        for (int i = 0; i < hand.cardSlotsInHand.Count; i++)
        {
            if (hand.cardSlotsInHand[i].activeSelf == true)
            {
                for (int j = 0; j < i; j++)
                {
                    if (hand.cardSlotsInHand[j].activeSelf == false)
                    {
                        hand.cardSlotsInHand[j].GetComponent<CardDisplay>().card = hand.cardSlotsInHand[i].GetComponent<CardDisplay>().card;
                        hand.cardsInHand.Remove(hand.cardSlotsInHand[i]);
                        hand.cardsInHand.Add(hand.cardSlotsInHand[j]);
                        hand.cardSlotsInHand[i].SetActive(false);
                        hand.cardSlotsInHand[j].SetActive(true);
                        break;
                    }
                }

            }
        }
    }

    public void SwitchTurn(ServerResponse response)
    {
        print("switchar eden tur");
        TriggerEndStep(response);
        // spelaren med priority end of turn effects triggrar aka EndOfTurnEffects(Player player1)

        TriggerUpKeep(response);
        // spelaren med priority upkeep effects triggrar aka UpkeepEffects(Player player2)
        hasPriority = false;
    }

    public void TriggerEndStep(ServerResponse response)
    {
        print("Den triggrar endstep");
        //Trigger Champion EndStep
        //Trigger Landmark EndStep
    }


    public void EndTurn()
    {
        if (isPlayerOnesTurn)
        {
            isPlayerOnesTurn = false;
            if (!playerOneStarted)
            {
                amountOfTurns++;
                actionOfPlayer.playerMana++;
            }
        }
        else
        {
            isPlayerOnesTurn = true;
            if (playerOneStarted)
            {
                amountOfTurns++;
                actionOfPlayer.playerMana++;
            }
        }

        DrawCard(1);
    }

    public void TriggerUpKeep(ServerResponse response)
    {
        //Trigger Champion Upkeep
        //Trigger Landmark Upkeep

        print("Den triggrar upkeep");
        EndTurn();

        //Gain a mana
        //Draw a card
    }

    public void OnChampionDeath(ServerResponse response)
    {
        if (response.whichPlayer == ClientConnection.Instance.playerId)
        {

            //Choose Champion
            //Pass priority
            //hasPriority = true;
        }
        else
        {
            //hasPriority = false;
        }
    }

    public void ChampionDeath(AvailableChampion chapionDeath)
    {
        if (playerChampion == chapionDeath)
        {
            playerChampions.Remove(playerChampion);
            playerChampion = null;
        }
        else if (opponentChampion == chapionDeath)
        {
            opponentChampions.Remove(opponentChampion);
            opponentChampion = null;
        }
        else
        {
            SearchDeadChampion(chapionDeath);
        }

        if (playerChampions.Count <= 0)
        {
            //Defeat
        }
        else if (opponentChampions.Count <= 0)
        {
            //Victory
        }
    }

    private void SearchDeadChampion(AvailableChampion champion)
    {
        if (playerChampions.Contains(champion.champion))
        {
            playerChampions.Remove(champion.champion);
        }
        else if (opponentChampions.Contains(champion.champion))
        {
            opponentChampions.Remove(champion.champion);
        }
    }

    public void RequestDiscardCard(ServerResponse response)
    {
        ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

        DiscardCard(castedResponse.listOfCardsDiscarded);
    }
    public void DiscardCard(List<string> listOfCardsDiscarded)
    {

    }
    public void RequestHeal(ServerResponse response)
    {
        ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

        DiscardCard(castedResponse.listOfCardsDiscarded);
    }
    public void Heal(List<Tuple<TargetInfo, int>> targetsToHeal)
    {

    }
    public void RequestDamage(ServerResponse response)
    {
        ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

        DiscardCard(castedResponse.listOfCardsDiscarded);
    }
    public void Damage(List<Tuple<TargetInfo, int>> targetsToDamage)
    {

    }
}
