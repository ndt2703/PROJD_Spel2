using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRegister : MonoBehaviour
{
    private static CardRegister instance;
    public static CardRegister Instance { get { return instance; } set { value = instance; } }

    [SerializeField] private List<Card> cards = new List<Card>();
    public Dictionary<string, Card> cardRegister = new Dictionary<string, Card>();
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(this);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
