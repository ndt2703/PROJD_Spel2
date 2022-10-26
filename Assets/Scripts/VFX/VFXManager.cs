using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void ArmorAction();
    public static event ArmorAction OnArmorTriggrt;


    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            if (OnArmorTriggrt != null)
 
                OnArmorTriggrt();
        }
    }
}
