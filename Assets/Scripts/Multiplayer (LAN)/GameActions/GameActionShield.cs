using System.Collections;
using System.Collections.Generic;
using System;

public class GameActionShield : GameAction
{
    public List<TargetAndAmount> targetsToShield = new List<TargetAndAmount>();

    public GameActionShield()
    {
        Type = 6;
    }
    public GameActionShield(List<TargetAndAmount> targetsToShield)
    {
        this.targetsToShield = targetsToShield;

        Type = 6; 
    }
}
