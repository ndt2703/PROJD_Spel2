using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Shanker", menuName = "Champion/Shanker", order = 1)]
public class Shanker : Champion
{
	private int attackCardsPlayed = 0;
	private int attackCardsToDraw = 3;
	private int cardsDrawn = 3;

	public Shanker(Shanker c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect, c.mesh)
	{
		attackCardsPlayed = c.attackCardsPlayed;
		attackCardsToDraw = c.attackCardsToDraw;
		cardsDrawn = c.cardsDrawn;
	}

	public override void AmountOfCardsPlayed()
	{
		base.AmountOfCardsPlayed();
		if(true /* Played an attack card */)
		{
			attackCardsPlayed++;
		}
	}

	public override void EndStep()
	{
		base.EndStep();
		if (attackCardsPlayed >= attackCardsToDraw)
		{
			//Choice: do the player want to draw cards???
			// if yes draw card
		}
		attackCardsPlayed = 0;
	}
}
