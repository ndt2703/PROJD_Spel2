using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllChampions : MonoBehaviour
{
    private static AllChampions instance;
    public static AllChampions Instance { get { return instance; } set { instance = value; } }
    private static List<Champion> subClasses = new List<Champion>();
    public List<Champion> SubClasses { get { return subClasses; }}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
