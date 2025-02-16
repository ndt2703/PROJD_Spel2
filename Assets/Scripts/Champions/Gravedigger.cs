using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Gravedigger", menuName = "Champion/Gravedigger", order = 1)]
public class Gravedigger : Champion
{
	public Gravedigger(Gravedigger c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect, c.mesh) { }

	public override void EndStep()
	{
		base.EndStep();
		if (Graveyard.Instance.graveyardPlayer.Count == 0) return;
		Tuple<Card, int> info = Graveyard.Instance.RandomizeCardFromGraveyard();
		GameState.Instance.DrawCard(1, info.Item1);
		if (GameState.Instance.isOnline)
		{
			TargetInfo targetInfo = new TargetInfo();
			targetInfo.whichList.myGraveyard = true;
			targetInfo.index = info.Item2;
			RequestRemoveCardsGraveyard request = new RequestRemoveCardsGraveyard();
			request.whichPlayer = ClientConnection.Instance.playerId;
			List<TargetInfo> list = new List<TargetInfo>();
			list.Add(targetInfo);
			request.cardsToRemoveGraveyard = list;
			ClientConnection.Instance.AddRequest(request, GameState.Instance.RequestEmpty);


			RequestAddSpecificCardToHand requestAddSpecificCardToHand = new RequestAddSpecificCardToHand();
			requestAddSpecificCardToHand.whichPlayer = ClientConnection.Instance.playerId;

			requestAddSpecificCardToHand.cardToAdd = info.Item1.cardName;

			ClientConnection.Instance.AddRequest(requestAddSpecificCardToHand, GameState.Instance.RequestEmpty);

		}

	}
}
