using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject championToProtect;
    [SerializeField] private EffectController VFXManager;
    // Start is called before the first frame update
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Test"))
        {
            VFXManager.ActiveShield(championToProtect, 10);
        }
    }
}
