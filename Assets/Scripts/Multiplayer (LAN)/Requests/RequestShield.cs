using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class RequestShield : ClientRequest
{


    public List<Tuple<TargetInfo, int>> targetsToShield = new List<Tuple<TargetInfo, int>>(); 
    public RequestShield()
    {
        Type = 7; 
    }

    public RequestShield(List<Tuple<TargetInfo, int>> targetsToShield)
    {


        Type = 7;

        this.targetsToShield = targetsToShield; 


    }
    
    
}
