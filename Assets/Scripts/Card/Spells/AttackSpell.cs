using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/AttackSpell")]
public class AttackSpell : Spells
{
    public int damage;
    private Champion targetChampion;
    private bool firstTime = true;

    public override void PlaySpell()
    {
        if (firstTime)
        {
            FindChampion();
        }
        targetChampion.TakeDamage(damage);
    }

    private void FindChampion()
    {
        targetChampion = FindObjectOfType<Champion>();
        firstTime = false;
    }
}
