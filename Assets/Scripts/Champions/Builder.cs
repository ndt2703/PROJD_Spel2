using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Builder", menuName = "Champion/Builder", order = 1)]
public class Builder : Champion
{
	private int landmarkCount = 0;
	private int landmarkNeeded = 2;
	private int cardCostReduce = 2;

	public Builder(Builder c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect)
	{
		landmarkCount = c.landmarkCount;
		landmarkNeeded = c.landmarkNeeded;
		cardCostReduce = c.cardCostReduce;
	}

	public override void Awake()
	{
		base.Awake();
		passiveEffect = landmarkCount + "/" + landmarkNeeded;
	}

	public override void AmountOfCardsPlayed()
	{
		base.AmountOfCardsPlayed();
		if (true /* if card played is a landmark */)
		{
			landmarkCount++;
			passiveEffect = landmarkCount + "/" + landmarkNeeded;
			if (landmarkCount >= landmarkNeeded)
			{
				//every card in hand 
				//minus two
			}
		}
	}

	public override void WhenLandmarksDie()
	{
		base.WhenLandmarksDie();
		if (landmarkCount == landmarkNeeded)
		{
			//every card in hand 
			//plus two
			cardCostReduce += 0;
		}
		landmarkCount--;
		passiveEffect = landmarkCount + "/" + landmarkNeeded;

	}

	public override void DrawCard()
	{
		base.DrawCard();
		if (landmarkCount >= landmarkNeeded)
		{
			//reduce the card drawn by two
		}
	}

}
