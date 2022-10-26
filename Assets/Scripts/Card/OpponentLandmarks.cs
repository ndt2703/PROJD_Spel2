using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentLandmarks : MonoBehaviour
{
    private GameState gameState;

    public LandmarkDisplay[] landmarkDisplays = new LandmarkDisplay[4];
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
                if (gameState.opponentLandmarks[i] == null)
                {
                    landmarkDisplays[i].card = null;
                    continue;
                }
                if (landmarkDisplays[i].card != null) continue;
                
                landmarkDisplays[i].card = gameState.opponentLandmarks[i];                  
            }
        }
    }
}
