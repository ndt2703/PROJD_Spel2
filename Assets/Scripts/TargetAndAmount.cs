using System.Collections;
using System.Collections.Generic;

public class TargetAndAmount
{
    public TargetInfo targetInfo;
    public int amount;
    public Champion championTarget;
    public LandmarkDisplay landmarkTarget;
    public int damage;
    public TargetAndAmount(Champion champTargeted, int damage) 
    {
        championTarget = champTargeted;
        this.damage = damage;
    }
    public TargetAndAmount(LandmarkDisplay landmarkTargeted, int damage) 
    {
        landmarkTarget = landmarkTargeted;
        this.damage = damage;
    }
}
