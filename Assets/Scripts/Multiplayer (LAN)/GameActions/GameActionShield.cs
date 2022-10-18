using System.Collections;
using System.Collections.Generic;
using System;

public class GameActionShield : GameAction
{
    public List<Tuple<TargetInfo, int>> targetsToShield = new List<Tuple<TargetInfo, int>>();

    public GameActionShield()
    {
        Type = 6;
    }
    public GameActionShield(List<Tuple<TargetInfo, int>> targetsToShield)
    {
        this.targetsToShield = targetsToShield;

        Type = 6; 
    }
}
