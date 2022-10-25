using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAndAmount : MonoBehaviour
{
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
