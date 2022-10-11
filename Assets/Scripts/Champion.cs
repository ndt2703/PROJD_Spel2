using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    public int health;
    public int shield;

    private int differenceAfterShieldDamage;
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
    }
    public void GainShield(int amountToBlock)
    {
        shield += amountToBlock;
    }
}
