using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Gravedigger", menuName = "Champion/Gravedigger", order = 1)]
public class Gravedigger : Champion
{
	public override void EndStep()
	{
		int i = Random.Range(0, 3 + 1);
		// Take a random card from Graveyard (removed from graveyard)

		base.EndStep();
	}
}
