using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableChampion : MonoBehaviour
{
	// Start is called before the first frame update
	public Champion champion;

	public new string name;
    public int health;
	public Text description;
	private int maxHealth;
    public int shield;

	public Sprite artwork;

	private void Awake()
	{
		champion.name = name;
		champion.description = description;
		champion.health = health;
		champion.shield = shield;
		maxHealth = health;
	}

	private void UpdateTextOnCard()
	{
		if (champion == null) return;

		name = champion.name;
		description.text = champion.description.text;
		artwork = champion.artwork;
	}
}
