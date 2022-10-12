using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionHeal : GameAction
{

    int amountToHeal = 0; 

    public GameActionHeal() { } // ta ej bort

    public GameActionHeal(int amountToHeal)
    {
        this.amountToHeal = amountToHeal;

        Type = 3; 
    }
}
