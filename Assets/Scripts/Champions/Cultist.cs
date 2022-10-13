using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cultist", menuName = "Champion/Cultist", order = 1)]
public class Cultist : Champion
{
	public int perMissingHP = 20;
	public int damagePerMissingHP = 5;
	public override void DealDamageAttack(int damage)
	{
		damage += damagePerMissingHP * (maxHealth / perMissingHP);
		base.DealDamageAttack(damage);
	}
}
