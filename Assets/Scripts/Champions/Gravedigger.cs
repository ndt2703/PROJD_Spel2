using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Gravedigger", menuName = "Champion/Gravedigger", order = 1)]
public class Gravedigger : Champion
{
	public Gravedigger(Gravedigger c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect) { }

	public override void EndStep()
	{
		base.EndStep();
		Card card = FindObjectOfType<Graveyard>().RandomizeCardFromGraveyard();
		// Add the card to playerhand
	}
}
