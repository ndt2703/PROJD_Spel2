using System.Collections;
using System.Collections.Generic;
using System;

public class GameActionSwitchActiveChamp : GameAction
{

    public Tuple<TargetInfo, TargetInfo> targetsToSwitch = new Tuple<TargetInfo,TargetInfo>(new TargetInfo(), new TargetInfo());
    // Start is called before the first frame update
    
    public GameActionSwitchActiveChamp()
    {
        Type = 7; 
    }    
    public GameActionSwitchActiveChamp(Tuple<TargetInfo, TargetInfo> targetsToSwitch)
    {
        Type = 7;

        this.targetsToSwitch = targetsToSwitch; 
    }
}
