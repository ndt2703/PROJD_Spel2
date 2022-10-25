using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentLandmarks : MonoBehaviour
{
    private GameState gameState;

    public List<GameObject> allOpponentLandmarkSlots = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameState.opponentLandmarks.Count > 0)
        {
            for (int i = 0; i < gameState.opponentLandmarks.Count; i++)
            {
                LandmarkDisplay landmarkDisplay = allOpponentLandmarkSlots[i].GetComponent<LandmarkDisplay>();
                if (landmarkDisplay.card != null) continue;

                landmarkDisplay.card = gameState.opponentLandmarks[i];
            }
        }
    }
}
