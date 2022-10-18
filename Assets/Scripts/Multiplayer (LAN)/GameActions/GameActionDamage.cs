using System.Collections;
using System.Collections.Generic;
using System; 

public class GameActionDamage : GameAction
{
    // Start is called before the first frame update
    public List<Tuple<TargetInfo, int>> targetsToDamage = new List<Tuple<TargetInfo, int>>();

    public GameActionDamage()
    {
        Type = 5;
    }

    public GameActionDamage(List<Tuple<TargetInfo,int>> targetsToDamage)
    {
        Type = 5;

        this.targetsToDamage = targetsToDamage; 
    }
}
