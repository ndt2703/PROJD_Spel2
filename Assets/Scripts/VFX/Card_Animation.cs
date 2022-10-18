using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Animation : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    public void OnMouseExit()
    {
        transform.localScale =  Vector3.one;
    }
}
