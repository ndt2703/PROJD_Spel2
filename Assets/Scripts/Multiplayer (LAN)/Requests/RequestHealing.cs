using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class RequestHealing : ClientRequest
{
    public List<Tuple<TargetInfo, int>> targetsToHeal = new List<Tuple<TargetInfo, int>>(); 
    
    // Start is called before the first frame update
    public RequestHealing() 
    {
        Type = 4;
    }// ta ej bortr
    public RequestHealing(List<Tuple<TargetInfo, int>> targetsToHeal)
    {
        this.targetsToHeal = targetsToHeal; 
        Type = 4; 
    }
}
