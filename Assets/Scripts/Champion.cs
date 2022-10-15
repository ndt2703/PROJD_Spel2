using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Champion : ScriptableObject
{
    public new string name;
    public string description;
    public int health;
    protected int maxHealth;
    public int shield;
    public Sprite artwork;
    public string passiveEffect;


    public virtual void Awake()
	{
        maxHealth = health;
        Debug.Log("wallahs");
    }

	public virtual void TakeDamage(int damage)
    {
        if (shield == 0)
        {
            health -= damage;           
        }
        else
        {
            if (damage > shield)
            {
                int differenceAfterShieldDamage = damage - shield;
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

    public virtual void HealChampion(int amountToHeal)
    {
        health += amountToHeal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public virtual void GainShield(int amountToBlock)
    {
        shield += amountToBlock;
    }

    public virtual void DealDamageAttack(int damage) {}

    public virtual void UpKeep() {/* Draw a card???? */}

    public virtual void EndStep() {}

    public virtual void WhenCurrentChampion () {}


}
