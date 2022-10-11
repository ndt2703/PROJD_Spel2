using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int currentPlayerID = 0;
    public bool hasPriority = true;

    public int playerOneMana;
    public int playerTwoMana;
    public int maxMana = 10;
    public int currentMana;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool LegalEndTurn()
    {
        if(hasPriority && currentPlayerID == ClientConnection.Instance.playerId)
        {
            return true;
        }
        return false;
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
        //Trigger Champion EndStep
        //Trigger Landmark EndStep
    }

    public void TriggerUpKeep(ServerResponse response)
    {
        //Trigger Champion Upkeep
        //Trigger Landmark Upkeep

        print("Den triggrar upkeep");
        switch (currentPlayerID)
        {
            case 0:
                currentPlayerID = 1;
                if (playerTwoMana < maxMana)
                {
                    playerTwoMana++;
                }
                currentMana = playerTwoMana;
                break;

            case 1:
                currentPlayerID = 0;
                if (playerOneMana < maxMana)
                {
                    playerOneMana++;
                }
                currentMana = playerOneMana;
                break;
        }
        //Gain a mana
        //Draw a card
    }

    public void OnChampionDeath(ServerResponse response)
    {
        if (response.whichPlayer == ClientConnection.Instance.playerId)
        {
            //Choose Champion
            //Pass priority
            hasPriority = true;
        }
        else
        {
            hasPriority = false;
        }
     }
}
