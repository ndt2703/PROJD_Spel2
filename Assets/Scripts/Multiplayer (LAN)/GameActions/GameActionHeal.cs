using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class GameActionHeal : GameAction
{

    public List<Tuple<TargetInfo,int>> targetsToHeal = new List<Tuple<TargetInfo, int>>(); 

    public GameActionHeal() 
    {
        Type = 3; 
    } 

    public GameActionHeal(List<Tuple<TargetInfo, int>> targetsToHeal)
    {
        this.targetsToHeal = targetsToHeal;

        Type = 3; 
    }
}
