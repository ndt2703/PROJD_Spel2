using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private static PlayerUI instance;
    public static PlayerUI Instance { get; set; }

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

    public void EndTurn()
    {
        if (GameState.Instance.LegalEndTurn())
        {
            RequestEndTurn request = new RequestEndTurn(ClientConnection.Instance.playerId);
            ClientConnection.Instance.AddRequest(request, GameState.Instance.SwitchTurn);

        }
    }
}
