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
	private int maxHealth;
    public int shield;

    public TMP_Text healthText;
	public TMP_Text description;
	public TMP_Text passiveEffect;

	public SpriteRenderer artwork;

	private void Awake()
	{
		champion.Awake();
        name = champion.name;
        artwork.sprite = champion.artwork;
        champion = (Champion) ScriptableObject.CreateInstance(champion.name);
		description.text = champion.description;
		healthText.text = champion.health.ToString();
		shield = champion.shield;
		maxHealth = champion.health;
		passiveEffect.text = champion.passiveEffect;

		//InvokeRepeating(nameof(Deal5Damage), 2, 20);
	}

    private void Deal5Damage()
    {
        TakeDamage(5);
    }

	private void UpdateTextOnCard()
	{
		if (champion == null) return;

		name = champion.name;
		description.text = champion.description;
		artwork.sprite = champion.artwork;
		passiveEffect.text = champion.passiveEffect;
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
            Debug.Log("Enemy died");
        }
    }

    public virtual void HealChampion(int amountToHeal)
    {
        health += amountToHeal + champion.HealChampionEffect();
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public virtual void GainShield(int amountToBlock)
    {
        shield += amountToBlock + champion.GainShieldEffect();
    }

    public virtual void DrawCard() { champion.DrawCard(); }

    public virtual void PlayCardEffect() { champion.PlayCardEffect(); }

    public virtual void DealDamageAttack(int damage) { damage += champion.DealDamageEffect(); }

    public virtual void UpKeep() { champion.UpKeepEffect(); }

    public virtual void EndStep() { champion.EndStepEffect(); }

    public virtual void WhenCurrentChampion() { champion.WhenCurrentChampionEffect(); }

    public virtual void WhenLandmarksDie() { champion.WhenLandmarksDie(); }

    public virtual void Death() { champion.Death(); }


    public void FixedUpdate()
	{
		UpdateTextOnCard();
	}
}