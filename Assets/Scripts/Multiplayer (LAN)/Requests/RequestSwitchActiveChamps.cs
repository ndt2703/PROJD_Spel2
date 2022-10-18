using System.Collections;
using System.Collections.Generic;
using System;

public class RequestSwitchActiveChamps : ClientRequest
{
    public Tuple<TargetInfo, TargetInfo> targetsToSwitch = new Tuple<TargetInfo, TargetInfo>(new TargetInfo(), new TargetInfo());

    public RequestSwitchActiveChamps()
    {
        Type = 8; 
    }
    public RequestSwitchActiveChamps(Tuple<TargetInfo, TargetInfo> targetsToSwitch)
    {
        Type = 8;

        this.targetsToSwitch = targetsToSwitch;
    }
}
