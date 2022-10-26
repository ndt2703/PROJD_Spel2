using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/AttackSpell")]
public class AttackSpell : Spells
{
    public int damage = 10;
    public bool destroyLandmark = false;
    public bool damageEqualsToYourChampionHP = false;
    public bool damageToBothActiveChampions = false;


    public override void PlaySpell()
    {
        int dmg = GameState.Instance.playerChampion.champion.DealDamageAttack(damage);
        if (damageEqualsToYourChampionHP)
            DamageAsYourChampionHP();
        if (Target != null)
            Target.TakeDamage(dmg);

        if (LandmarkTarget != null)
            LandmarkTarget.TakeDamage(dmg);

        if (destroyLandmark)
            GameState.Instance.DestroyLandmark();
        if (damageToBothActiveChampions)
        { // Funkar inte då inte någon åtkomst till ActiveChampion skriptet
            GameState.Instance.playerChampion.champion.TakeDamage(dmg);
            GameState.Instance.opponentChampion.champion.TakeDamage(dmg);
        }
            

    }

    private void DamageAsYourChampionHP()
    {
        damage = GameState.Instance.playerChampion.health;
    }
}
