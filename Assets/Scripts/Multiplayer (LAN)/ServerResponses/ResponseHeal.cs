using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class ResponseHeal : ServerResponse
{
    public List<Tuple<TargetInfo, int>> targetsToHeal =  new List<Tuple<TargetInfo, int>>(); 
    public ResponseHeal()
    {
        Type = 4; 
    }

    public ResponseHeal(List<Tuple<TargetInfo, int>> targetsToHeal)
    {
        Type = 4;
        this.targetsToHeal = targetsToHeal;
    }
}
