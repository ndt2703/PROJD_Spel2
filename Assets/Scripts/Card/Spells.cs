using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : Card
{   
    public override void PlayCard()
    {
        PlaySpell();
    }
    public abstract void PlaySpell();
}
