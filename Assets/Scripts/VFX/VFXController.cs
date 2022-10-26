using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    [SerializeField] private GameObject ownArmor;
    [SerializeField] private GameObject opponentArmor;
    // Start is called before the first frame update
    void Start()
    {
        ownArmor.SetActive(true);
        opponentArmor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
