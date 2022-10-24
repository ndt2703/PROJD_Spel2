using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public int manaCost;

    public string tag;

    private Champion target;
    private LandmarkDisplay landmarkTarget;
    public Champion Target { get { return target; } set { target = value; } }
    public LandmarkDisplay LandmarkTarget { get { return landmarkTarget; } set { landmarkTarget = value; } }

    public abstract void PlayCard();

    
}
