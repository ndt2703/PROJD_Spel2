using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Shanker", menuName = "Champion/Shanker", order = 1)]
public class Shanker : Champion
{
	private int attackCardsToDraw = 3;
	private int cardsDrawn = 3;

	public Shanker(Shanker c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect, c.mesh)
	{
		attackCardsToDraw = c.attackCardsToDraw;
		cardsDrawn = c.cardsDrawn;
	}

	public override void EndStep()
	{
		base.EndStep();
		GameState gameState = GameState.Instance;
		int attackCardsPlayed = 0;
		foreach (Card c in gameState.cardsPlayedThisTurn)
		{
			if (c.typeOfCard == CardType.Attack)
			{
				attackCardsPlayed++;
			}
		}

		if (attackCardsPlayed >= attackCardsToDraw)
		{
			gameState.DrawCard(attackCardsToDraw, null);
		}
	}
}
