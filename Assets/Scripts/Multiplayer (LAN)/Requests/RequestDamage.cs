using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDamage : ClientRequest
{
    public List<TargetAndAmount> targetsToDamage = new List<TargetAndAmount>;

    public RequestDamage()
    {   
        
        Type = 6; 
    }
    public RequestDamage(List<TargetAndAmount> targetsToDamage)
    {
        this.targetsToDamage = targetsToDamage;
        Type = 6; 
    }

}
