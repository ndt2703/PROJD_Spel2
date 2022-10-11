using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Landmarks : Card
{
    public int minionHealth;
    public int minionDamage;

    public override void PlayCard()
    {
        PlaceLandmark();
    }

    public abstract void PlaceLandmark();

}
