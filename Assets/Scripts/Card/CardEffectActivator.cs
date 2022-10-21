using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
    }
}
