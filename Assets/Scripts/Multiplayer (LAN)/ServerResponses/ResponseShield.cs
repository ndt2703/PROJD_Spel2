using System.Collections;
using System.Collections.Generic;
using System;

public class ResponseShield : ServerResponse
{

    public  List<TargetAndAmount> targetsToShield = new List<TargetAndAmount>();
    public ResponseShield()
    {
        Type = 6;
    }

    public ResponseShield(List<TargetAndAmount> targetsToShield)
    {
        this.targetsToShield = targetsToShield;
        Type = 6; 
    }



}
