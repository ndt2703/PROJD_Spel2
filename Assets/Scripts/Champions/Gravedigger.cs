using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Gravedigger", menuName = "Champion/Gravedigger", order = 1)]
public class Gravedigger : Champion
{
	public override void EndStepEffect()
	{
		// Take a random card from Graveyard (removed from graveyard)
		base.EndStepEffect();
		Card card = FindObjectOfType<Graveyard>().RandomizeCardFromGraveyard();
		// Add card to hand
	}
}
