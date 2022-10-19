using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Animation : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
    }
    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
}
