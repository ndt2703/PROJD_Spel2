using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cultist", menuName = "Champion/Cultist", order = 1)]
public class Cultist : Champion
{
	public int perMissingHP = 20;
	public int damagePerMissingHP = 10;

	public int currentBonusDamage = 0;

	public override void Awake()
	{
		base.Awake();
		passiveEffect = currentBonusDamage + "+";
	}

	public override int DealDamageEffect()
	{
		return currentBonusDamage;
	}

	public override void AfterEffectTriggered()
	{
		ChangeBonusDamage();
	}

	private void ChangeBonusDamage()
	{
		//int difference = (maxHealth - health) / perMissingHP;
		//Mathf.Floor(difference);
		//currentBonusDamage = damagePerMissingHP * difference;
		//passiveEffect = currentBonusDamage + "+";
	}
}
