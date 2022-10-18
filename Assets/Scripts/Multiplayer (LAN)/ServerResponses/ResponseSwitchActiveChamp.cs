using System.Collections;
using System.Collections.Generic;
using System;

public class ResponseSwitchActiveChamp : ServerResponse
{
    public Tuple<TargetInfo, TargetInfo> targetsToSwitch = new Tuple<TargetInfo, TargetInfo>(new TargetInfo(), new TargetInfo());

    public ResponseSwitchActiveChamp()
    {
        Type = 7;
    }

    public ResponseSwitchActiveChamp(Tuple<TargetInfo, TargetInfo> targetsToSwitch)
    {
        Type = 7;

        this.targetsToSwitch = targetsToSwitch; 
    }
}
