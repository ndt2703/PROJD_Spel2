using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int currentPlayerTurn = 0;
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

    public void SwitchTurn()
    {
        switch (currentPlayerTurn)
        {
            case 0:
                currentPlayerTurn = 1;
                if (playerTwoMana < maxMana)
                {
                    playerTwoMana++;
                }
                currentMana = playerTwoMana;
                break;

            case 1:
                currentPlayerTurn = 0;
                if (playerOneMana < maxMana)
                {
                    playerOneMana++;
                }
                currentMana = playerOneMana;
                break;
        }
        //Send request
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

        // Adds into the graveyard
     }
}
