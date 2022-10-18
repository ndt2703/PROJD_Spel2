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

	public override void PlayCardEffect()
	{
		base.PlayCardEffect();
		if(true /* Played an attack card */)
		{
			attackCardsPlayed++;
		}
	}

	public override void EndStepEffect()
	{
		base.EndStepEffect();
		if (attackCardsPlayed >= attackCardsToDraw)
		{
			//Choice: do the player want to draw cards???
			// if yes draw card
			cardsDrawn += 0;
		}
		attackCardsPlayed = 0;
	}
}
