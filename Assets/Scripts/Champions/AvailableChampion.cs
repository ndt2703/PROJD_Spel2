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


    public TMP_Text healthText;
    public TMP_Text shieldText;
    public TMP_Text passiveEffect;

	public SpriteRenderer artwork;



	private void Awake()
	{
        name = champion.name;
        artwork.sprite = champion.artwork;
        passiveEffect.text = champion.passiveEffect;
        health = champion.health;
        maxHealth = champion.maxHealth;

		//InvokeRepeating(nameof(Deal5Damage), 5, 2);
	}

	private void Start()
	{
        maxHealth = health;
	}

	private void Deal5Damage()
    {
        champion.TakeDamage(5);
    }

    /*
    public void ChangeChampion(Champion champion, int currentHealth, int currentShield)
    {
        this.champion = champion;
        Awake();
        health = currentHealth;
        shield = currentShield;
    }
    */

	private void UpdateTextOnCard()
    {
        if (champion == null) return;

        health = champion.health;
        maxHealth = champion.maxHealth;
        shield = champion.shield;
        passiveEffect.text = champion.passiveEffect;
        healthText.text = health + "/" + maxHealth;
        //shieldText.text = shield + "";
	}

    public void FixedUpdate()
	{
		UpdateTextOnCard();
	}
}
