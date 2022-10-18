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

    public virtual void DrawCard() { AfterEffectTriggered(); }

    public virtual void PlayCardEffect() { AfterEffectTriggered(); }

    public virtual int TakeDamageEffect() { AfterEffectTriggered(); return 0; }

    public virtual int HealChampionEffect() { AfterEffectTriggered(); return 0; }

    public virtual int GainShieldEffect() { AfterEffectTriggered(); return 0; }

    public virtual int DealDamageEffect() { AfterEffectTriggered(); return 0; }

    public virtual void UpKeepEffect() { AfterEffectTriggered(); }

    public virtual void EndStepEffect() { AfterEffectTriggered(); }

    public virtual void WhenCurrentChampionEffect() { AfterEffectTriggered(); }

    public virtual void WhenLandmarksDie() { AfterEffectTriggered(); }

    public virtual void AfterEffectTriggered() { AfterEffectTriggered(); }

    public virtual void Death() { }

}
