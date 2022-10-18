using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public abstract class Champion : ScriptableObject
{
    public new string name;
    public string description;
    public int health;
    public int shield;
    public Sprite artwork;
    public string passiveEffect;


    public virtual void Awake() { }

    public virtual int TakeDamageEffect() { return 0; }

    public virtual int HealChampionEffect() { return 0; }
    public virtual int GainShieldEffect() { return 0; }

    public virtual int DealDamageEffect() { return 0; }

    public virtual void UpKeepEffect() { }

    public virtual void EndStepEffect() { }

    public virtual void WhenCurrentChampionEffect() { }

    public virtual void AfterEffectTriggered() { }
    public virtual void AfterEffectTriggered(int health) { }
}
