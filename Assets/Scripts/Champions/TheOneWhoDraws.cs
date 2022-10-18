using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TheOneWhoDraws", menuName = "Champion/TheOneWhoDraws", order = 1)]
public class TheOneWhoDraws : Champion
{
	public override void EndStepEffect()
	{
		base.EndStepEffect();
		if (true /*player chooses if he want to draw more */)
		{
			//Choice: do the player want to draw cards???
		}
	}
}
