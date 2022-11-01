using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionPlayLandmark : GameAction
{

	public CardAndPlacement landmarkToPlace = new CardAndPlacement();

	public GameActionPlayLandmark()
	{
		Type = 13;
	}
	public GameActionPlayLandmark(CardAndPlacement landmarkToPlace)
	{
		Type = 13;
		this.landmarkToPlace = landmarkToPlace; 
	}

}
