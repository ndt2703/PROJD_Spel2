using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Champions", menuName = "Champions", order = 1)]
public class Champion : MonoBehaviour //ScriptableObject
{
    public int health;
    private int maxHealth;
    public int shield;

    private int differenceAfterShieldDamage;

	public void Start()
	{
        maxHealth = health;
	}

	public void TakeDamage(int damage)
    {
        if (shield == 0)
        {
            health -= damage;           
        }
        else
        {
            if (damage > shield)
            {
                differenceAfterShieldDamage = damage - shield;
                shield = 0;
                health -= differenceAfterShieldDamage;
            }
            else
            {
                shield -= damage;
            }
        }
        
        if (health <= 0)
        {
            Debug.Log("Enemy died");
        }
    }

    public void HealChampion(int amountToHeal)
    {
        health += amountToHeal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void GainShield(int amountToBlock)
    {
        shield += amountToBlock;
    }
}
