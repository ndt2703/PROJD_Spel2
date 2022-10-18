using System.Collections;
using System.Collections.Generic;
using System;

public class ResponseShield : ServerResponse
{

    public List<Tuple<TargetInfo, int>> targetsToShield = new List<Tuple<TargetInfo, int>>();
    public ResponseShield()
    {
        Type = 6;
    }

    public ResponseShield(List<Tuple<TargetInfo, int>> targetsToShield)
    {
        this.targetsToShield = targetsToShield;
        Type = 6; 
    }



}
