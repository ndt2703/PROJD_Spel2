using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionHeal : GameAction
{

    public int amountToHeal = 0; 

    public GameActionHeal() 
    {
        Type = 3; 
    } 

    public GameActionHeal(int amountToHeal)
    {
        this.amountToHeal = amountToHeal;

        Type = 3; 
    }
}
