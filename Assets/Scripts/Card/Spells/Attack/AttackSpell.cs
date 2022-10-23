using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/AttackSpell")]
public class AttackSpell : Spells
{
    public int damage = 10;
    public bool destroyLandmark = false;
    public bool damageEqualsToYourChampionHP = false;


    public override void PlaySpell()
    {
        if (damageEqualsToYourChampionHP)
            DamageAsYourChampionHP();
        if (Target != null)
            Target.TakeDamage(damage);

        if (LandmarkTarget != null)
            LandmarkTarget.TakeDamage(damage);

        if (destroyLandmark)
            GameState.Instance.DestroyLandmark();
    }

    private void DamageAsYourChampionHP()
    {
        damage = GameState.Instance.playerChampion.health;
    }
}
