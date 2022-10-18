using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDamage : ClientRequest
{
    public List<Tuple<TargetInfo, int>> targetsToDamage = new List<Tuple<TargetInfo, int>>();

    public RequestDamage()
    {   
        
        Type = 6; 
    }
    public RequestDamage(List<Tuple<TargetInfo,int>> targetsToDamage)
    {
        this.targetsToDamage = targetsToDamage;
        Type = 6; 
    }

}
