using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public int manaCost; 

    public abstract void PlayCard();   
}
