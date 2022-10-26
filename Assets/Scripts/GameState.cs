using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class GameState : MonoBehaviour
{
    public int currentPlayerID = 0;
    public bool hasPriority = true;

    public bool isItMyTurn;
    private bool didIStart;

    public int amountOfTurns;

   
    private int amountOfCardsToStartWith = 5;


    private readonly int maxMana = 10;
    public ActionOfPlayer actionOfPlayer;
    public int currentMana;
    public SpriteRenderer playedCardSpriteRenderer;
    public Sprite backfaceCard;

    public GameObject EndTurnButton;
    private UnityEngine.UI.Button endTurnBttn;

    public AvailableChampion playerChampion;
    public AvailableChampion opponentChampion;
    [NonSerialized] public bool drawExtraCardsEachTurn = false;
    [NonSerialized] public int occultGathering = 0;

    public List<AvailableChampion> playerChampions = new List<AvailableChampion>();
    public List<AvailableChampion> opponentChampions = new List<AvailableChampion>();

    public List<Landmarks> playerLandmarks = new List<Landmarks>();
    public List<Landmarks> opponentLandmarks = new List<Landmarks>();

    public List<Card> cardsPlayedThisTurn = new List<Card>();

    [NonSerialized] public int tenExtraDamage;
    [NonSerialized] public int damageRamp = 0;
    [NonSerialized] public int slaughterhouse = 0;
    [NonSerialized] public int factory = 0;

    private static GameState instance;
    public static GameState Instance { get; set; }


    public bool isOnline = false;


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

        AddChampions(playerChampions);
        AddChampionsOpponent(opponentChampions);
        playerChampion = playerChampions[0];
        opponentChampion = opponentChampions[0];
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        actionOfPlayer = ActionOfPlayer.Instance;
        endTurnBttn = EndTurnButton.GetComponent<UnityEngine.UI.Button>();
        if (isOnline)
        {
            if (ClientConnection.Instance.playerId == 0)
            {
                isItMyTurn = true;
                didIStart = true; 
            }
            else
            {
                isItMyTurn = false;
                didIStart = false;
                ChangeInteractabiltyEndTurn();
            }
        }

        Invoke(nameof(DrawStartingCards), 0.01f);
    }

    private void ChangeInteractabiltyEndTurn()
    {
        endTurnBttn.interactable = !endTurnBttn.interactable;
    }

    public  void EndTurnButtonClick()
    {
        if(isOnline)
        {
            RequestEndTurn request = new RequestEndTurn();
            request.whichPlayer = ClientConnection.Instance.playerId;
            ClientConnection.Instance.AddRequest(request, RequestEndTurn);
        }

        EndTurn();
    }

    public void CalculateBonusDamage(int damage, Card cardUsed)
    {
        damage = playerChampion.champion.DealDamageAttack(damage);

        damage += damageRamp;

        if (slaughterhouse > 0)
        {
            for (int i = 0; i < playerLandmarks.Count; i++)
            {
                damage += 10 * slaughterhouse;
            }
        }

        if (tenExtraDamage > 0)
        {
            damage += (10 * tenExtraDamage);
        }

        TargetAndAmount tAA = null;

        if (cardUsed.Target != null)
            tAA = new TargetAndAmount(cardUsed.Target, damage);
        else if (cardUsed.LandmarkTarget != null)
            tAA = new TargetAndAmount(cardUsed.LandmarkTarget, damage);
        DealDamage(tAA);
    }

    public void DealDamage(TargetAndAmount targetAndAmount) // TargetAndAmount
    {
        if (targetAndAmount.championTarget != null)
            targetAndAmount.championTarget.TakeDamage(targetAndAmount.damage);
        else if (targetAndAmount.landmarkTarget != null)
            targetAndAmount.landmarkTarget.TakeDamage(targetAndAmount.damage);
    }

    private void AddChampions(List<AvailableChampion> champions)
    {
        for (int i = 0; i < champions.Count; i++)
        {
            Champion champ = null;
            switch (champions[i].champion.name)
            {
                case "Cultist":
                    champ = new Cultist((Cultist)champions[i].champion);
                    break;

                case "Builder":
                    champ = new Builder((Builder)champions[i].champion);
                    break;

                case "Shanker":
                    champ = new Shanker((Shanker)champions[i].champion);
                    break;

                case "Gravedigger":
                    champ = new Gravedigger((Gravedigger)champions[i].champion);
                    break;

                case "TheOneWhoDraws":
                    champ = new TheOneWhoDraws((TheOneWhoDraws)champions[i].champion);
                    break;

                case "Duelist":
                    champ = new Duelist((Duelist)champions[i].champion);
                    break;
            }
            playerChampions[i].champion = champ;
        }
    }

    private void AddChampionsOpponent(List<AvailableChampion> champions)
    {
        for (int i = 0; i < champions.Count; i++)
        {
            Champion champ = null;
            switch (champions[i].champion.name)
            {
                case "Cultist":
                    champ = new Cultist((Cultist)champions[i].champion);
                    break;

                case "Builder":
                    champ = new Builder((Builder)champions[i].champion);
                    break;

                case "Shanker":
                    champ = new Shanker((Shanker)champions[i].champion);
                    break;

                case "Gravedigger":
                    champ = new Gravedigger((Gravedigger)champions[i].champion);
                    break;

                case "TheOneWhoDraws":
                    champ = new TheOneWhoDraws((TheOneWhoDraws)champions[i].champion);
                    break;

                case "Duelist":
                    champ = new Duelist((Duelist)champions[i].champion);
                    break;
            }
            opponentChampions[i].champion = champ;
        }
    }

    private void DrawStartingCards()
    {
        StartCoroutine(DrawCardPlayer(amountOfCardsToStartWith, null));
        StartCoroutine(DrawCardOpponent(amountOfCardsToStartWith, null));
    }

  

    public void DrawCardRequest(ServerResponse response)
    {
        ResponseDrawCard castedReponse = (ResponseDrawCard)response;

        //DrawCard(castedReponse.amountToDraw, null);
    }

    public void DrawRandomCardFromGraveyard(int amountOfCards)
    {
        Card randomCardFromGraveyard = Graveyard.Instance.RandomizeCardFromGraveyard();
        DrawCardPlayer(amountOfCards, randomCardFromGraveyard);
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


    public void DestroyLandmark()
    {
        for (int i = 0; i < 25; i++)
        {
            int random = UnityEngine.Random.Range(0, opponentLandmarks.Count);
            if (opponentLandmarks[random] != null)
            {
                opponentLandmarks[random] = null;
                break;
            }
        }
    }

    public string DiscardWhichCard(bool yourself)
    {
        string discardedCard = "";
        if (yourself)
            discardedCard = actionOfPlayer.handPlayer.DiscardRandomCardInHand().name;
        else
            discardedCard = actionOfPlayer.handOpponent.DiscardRandomCardInHand().name;
        return discardedCard;
    }

    public void DiscardCard(int amountToDiscard, bool discardCardsYourself)
    {

        if (isOnline)
        {
            if (discardCardsYourself)
            {
                RequestDiscardCard request = new RequestDiscardCard();
                request.whichPlayer = ClientConnection.Instance.playerId;
                List<string> cardsDiscarded = new List<string>();
                for (int i = 0; i < amountToDiscard; i++)
                {
                    cardsDiscarded.Add(DiscardWhichCard(discardCardsYourself));
                }
                request.listOfCardsDiscarded = cardsDiscarded;

                ClientConnection.Instance.AddRequest(request, RequestDiscardCard);
            }
            else
            {
                RequestOpponentDiscardCard requesten = new RequestOpponentDiscardCard();
                requesten.whichPlayer = ClientConnection.Instance.playerId;
                requesten.amountOfCardsToDiscard = amountToDiscard;
                ClientConnection.Instance.AddRequest(requesten, RequestDiscardCard);

            }
        }
        else
        {
            for (int i = 0; i < amountToDiscard; i++)
            {
                DiscardWhichCard(discardCardsYourself);
            }
        }
    }

    public void DrawCard(int amountToDraw, Card specificCard)
    {
        //  ActionOfPlayer.Instance.DrawCard(amountOfCardsToDraw);
        if (isOnline)
        {
            RequestDrawCard request = new RequestDrawCard(amountToDraw);
            request.whichPlayer = ClientConnection.Instance.playerId;
            print("Should draw card");
            ClientConnection.Instance.AddRequest(request, DrawCardRequest);
            StartCoroutine(DrawCardPlayer(amountToDraw, specificCard));
        }
        else
        {
            StartCoroutine(DrawCardPlayer(amountToDraw, specificCard));
        }
    }


    public IEnumerator DrawCardPlayer(int amountToDraw, Card specificCard)
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

                if (specificCard == null)
                    cardDisplay.card = actionOfPlayer.handPlayer.deck.WhichCardToDraw();
                else
                    cardDisplay.card = specificCard;
                cardSlot.SetActive(true);
                drawnCards++;
            }
        }

    }
    public IEnumerator DrawCardOpponent(int amountToDraw, Card specificCard)
    {
        if (actionOfPlayer.handOpponent.cardsInHand.Count > 0)
        {
            ChangeCardOrder();
            yield return new WaitForSeconds(0.01f);
        }

        int drawnCards = 0;
        foreach (GameObject cardSlot in actionOfPlayer.handOpponent.cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null) continue;

            if (!cardSlot.activeSelf)
            {
                if (drawnCards >= amountToDraw) break;

                if (specificCard == null)
                {
                    cardDisplay.card = actionOfPlayer.handPlayer.deck.WhichCardToDraw();
                    cardDisplay.opponentCard = true;
                    cardDisplay.artworkSpriteRenderer.sprite = backfaceCard;
                }

                else
                    cardDisplay.card = specificCard;
                cardSlot.SetActive(true);
                drawnCards++;
            }
        }

    }

    public void SwapActiveChampion()
    {
        for (int i = 0; i < 25; i++)
        {
            int randomChamp = UnityEngine.Random.Range(0, playerChampions.Count);
            if (playerChampion != playerChampions[randomChamp])
            {
                Champion champ = playerChampion.champion;
                playerChampion.champion = playerChampions[randomChamp].champion;
                playerChampions[randomChamp].champion = champ;
                return; 

            }
        }

        //playerChampion.champion = playerChampions[randomChamp].champion; 
    }

    public void SwapActiveChampionEnemy()
    {
        for (int i = 0; i < 25; i++)
        {
            int randomChamp = UnityEngine.Random.Range(0, opponentChampions.Count);
            if (opponentChampion != opponentChampions[randomChamp])
            {
                Champion champ = opponentChampion.champion;
                opponentChampion.champion = opponentChampions[randomChamp].champion;
                opponentChampions[randomChamp].champion = champ;
                return;

            }
        }

        //playerChampion.champion = playerChampions[randomChamp].champion; 
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
        playerChampion.champion.EndStep();
        //opponentChampion.champion.EndStep();
        foreach (Landmarks landmark in playerLandmarks)
        {
            //Trigger landmark endstep
        }
        foreach (Landmarks landmark in opponentLandmarks)
        {
            //Trigger landmark endstep opponent
        }
        EndTurn();
    }


    public void EndTurn()
    {
        
        if (isItMyTurn)
        {
            ChangeInteractabiltyEndTurn();
            isItMyTurn = false;
            if (!didIStart)
            {
                DrawCard(1, null);
                if (drawExtraCardsEachTurn)
                {
                    DrawCard(1, null);
                }
                amountOfTurns++;
                actionOfPlayer.playerMana++;
                opponentChampion.champion.EndStep();
                playerChampion.champion.UpKeep();
            }
        }
        else
        {
            ChangeInteractabiltyEndTurn();
            isItMyTurn = true;
            DrawCard(1, null);
            if (didIStart)
            {
                if (drawExtraCardsEachTurn)
                {
                    DrawCard(1, null);
                }
                amountOfTurns++;
                actionOfPlayer.playerMana++;
                playerChampion.champion.EndStep();
                opponentChampion.champion.UpKeep();
            }
        }
        cardsPlayedThisTurn.Clear();
        damageRamp = 0;
    }

    public void AddCardToPlayedCardsThisTurn(Card cardPlayed)
    {
        cardsPlayedThisTurn.Add(cardPlayed);
        if (occultGathering > 0)
        {
            if (cardPlayed.GetType().Equals("AttackSpell"))
            {
                damageRamp += 10 * occultGathering;
            }
        }

        if (cardPlayed.GetType().Equals("Landmark"))
        {
            playerChampion.champion.AmountOfCardsPlayed();
        }
    }

    public void TriggerUpKeep(ServerResponse response)
    {
        print("Den triggrar upkeep");
        playerChampion.champion.UpKeep();
        //opponentChampion.champion.UpKeep();
        foreach (Landmarks landmark in playerLandmarks)
        {
            //Trigger landmark endstep
        }
        foreach (Landmarks landmark in opponentLandmarks)
        {
            //Trigger landmark endstep opponent
        }
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

    public void ChampionDeath(Champion deadChampion)
    {
        SearchDeadChampion(deadChampion);

        if (playerChampion == null)
        {
            print("Defeat");
        }
        else if (opponentChampion == null)
        {
            print("Victory");
        }
    }

    private void SearchDeadChampion(Champion deadChampion)
    {
        foreach (AvailableChampion ac in playerChampions)
        {
            if (ac.champion == deadChampion)
            {
                playerChampions.Remove(ac);
                break;
            }
        }
        foreach (AvailableChampion ac in opponentChampions)
        {
            if (ac.champion == deadChampion)
            {
                opponentChampions.Remove(ac);
                break;
            }
        }

        if (playerChampion.champion.GetType() == deadChampion.GetType())
        {
            SwapActiveChampion();
        }
        else if (opponentChampion.champion.GetType() == deadChampion.GetType())
        {
            SwapActiveChampionEnemy();
        }
    }


    public void RequestDiscardCard(ServerResponse response)
    {
        //ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

       // DiscardCard(castedResponse.listOfCardsDiscarded);
    }
    public void DiscardCard(List<string> listOfCardsDiscarded)
    {

    }
    public void RequestHeal(ServerResponse response)
    {
        //ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

        //DiscardCard(castedResponse.listOfCardsDiscarded);
    }
 

    public void RequestDamage(ServerResponse response)
    {
     //   ResponseDiscardCard castedResponse = (ResponseDiscardCard)response;

    //    DiscardCard(castedResponse.listOfCardsDiscarded);
    }
    public void RequestPlayCard(ServerResponse response)
    {

    }
    public void RequestEndTurn(ServerResponse response)
    {

    }
}
