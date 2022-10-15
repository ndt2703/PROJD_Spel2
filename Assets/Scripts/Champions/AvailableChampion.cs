using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvailableChampion : MonoBehaviour
{
	// Start is called before the first frame update
	public Champion champion;

	public new string name;
    public TMP_Text health;
	public TMP_Text description;
	private int maxHealth;
    public int shield;
	public TMP_Text passiveEffect;

	public SpriteRenderer artwork;

	private void Awake()
	{
		name = champion.name;
		description.text = champion.description;
		health.text = champion.health.ToString();
		shield = champion.shield;
		artwork.sprite = champion.artwork;
		maxHealth = champion.health;
		passiveEffect.text = champion.passiveEffect;

		champion.Awake();
		//InvokeRepeating(nameof(Deal5Damage), 2, 20);
	}

	private void Deal5Damage()
	{
		champion.TakeDamage(5);
	}

	private void UpdateTextOnCard()
	{
		if (champion == null) return;

		name = champion.name;
		description.text = champion.description;
		artwork.sprite = champion.artwork;
		passiveEffect.text = champion.passiveEffect;
	}

	public void FixedUpdate()
	{
		UpdateTextOnCard();
	}
}
