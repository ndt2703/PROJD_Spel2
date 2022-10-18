using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDamage : ServerResponse
{
    public List<Tuple<TargetInfo, int>> targetsToDamage = new List<Tuple<TargetInfo, int>>();


    public ResponseDamage()
    {
        Type = 5; 
    }
    public ResponseDamage(List<Tuple<TargetInfo,int>> targetsToDamage)
    {
        Type = 5;

        this.targetsToDamage = targetsToDamage; 
    }
}
