using System.Collections;
using System.Collections.Generic;
using System; 

public class GameActionDamage : GameAction
{
    // Start is called before the first frame update
    public List<TargetAndAmount> targetsToDamage = new List<TargetAndAmount>() ;

    public GameActionDamage()
    {
        Type = 5;
    }

    public GameActionDamage(List<TargetAndAmount> targetsToDamage)
    {
        Type = 5;

        this.targetsToDamage = targetsToDamage; 
    }
}
