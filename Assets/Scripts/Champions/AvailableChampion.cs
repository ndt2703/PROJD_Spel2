using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AvailableChampion : MonoBehaviour
{
	// Start is called before the first frame update
	public Champion champion;

	public new string name;
    public int health;
	public int maxHealth;
    public int shield;
    public int landmarkEffect = 1;

    public TMP_Text healthText;
    public TMP_Text shieldText;
    public TMP_Text passiveEffect;

	public SpriteRenderer artwork;

    public bool healEachRound = false;

	private void Awake()
	{
        name = champion.name;
        artwork.sprite = champion.artwork;
        passiveEffect.text = champion.passiveEffect;
        health = champion.health;
        maxHealth = champion.maxHealth;

		InvokeRepeating(nameof(Deal5Damage), 5, 2);
	}

	private void Start()
	{
        maxHealth = health;
	}

	private void Deal5Damage()
    {
        TakeDamage(5);
    }

    public void ChangeChampion(Champion champion, int currentHealth, int currentShield)
    {
        this.champion = champion;
        Awake();
        health = currentHealth;
        shield = currentShield;
    }

	private void UpdateTextOnCard()
    {
		passiveEffect.text = champion.passiveEffect;
        healthText.text = health + "/" + maxHealth;
        //shieldText.text = shield + "";
	}


    public virtual void TakeDamage(int damage)
    {
        damage += champion.TakeDamageEffect();
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
            Death();
        }
    }

    public void HealEachRound()
    {
        if (healEachRound)
        {
            HealChampion(10);
        }
    }

    public virtual void HealChampion(int amountToHeal)
    {
        health += amountToHeal + champion.HealChampionEffect() * landmarkEffect;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public virtual void GainShield(int amountToBlock)
    {
        shield += amountToBlock + champion.GainShieldEffect() * landmarkEffect;
    }

    public virtual void DrawCard() { champion.DrawCard(); }

    public virtual void PlayCardEffect() { champion.PlayCardEffect(); }

    public virtual void DealDamageAttack(int damage) { damage += champion.DealDamageEffect(); }

    public virtual void UpKeep() { champion.UpKeepEffect(); /* */ HealEachRound(); /* */ } // Osäker på om jag gjort rätt när jag la in den här

    public virtual void EndStep() { champion.EndStepEffect(); }

    public virtual void WhenCurrentChampion() { champion.WhenCurrentChampionEffect(); }

    public virtual void WhenLandmarksDie() { champion.WhenLandmarksDie(); }

    public virtual void Death()
    {
        champion.Death();
        CancelInvoke();
		GameState.Instance.ChampionDeath(this);
	}


    public void FixedUpdate()
	{
		UpdateTextOnCard();
	}
}
