using UnityEngine;
using UnityEngine.Events;

public class VFX_Manager : MonoBehaviour
{
    public delegate void VFX_Event();
    public static event VFX_Event OnMouseOver;



}
