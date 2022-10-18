using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Duelist", menuName = "Champion/Duelist", order = 1)]
public class Duelist : Champion
{
	public override void WhenCurrentChampionEffect()
	{
		base.WhenCurrentChampionEffect();
		//Choose Opponent champion
	}
}
