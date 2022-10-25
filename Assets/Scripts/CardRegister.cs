using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRegister : MonoBehaviour
{
    private static CardRegister instance;
    public static CardRegister Instance { get; set; }

    [SerializeField] private List<Card> cards = new List<Card>();
    public Dictionary<string, Card> cardRegister = new Dictionary<string, Card>();
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(this);
    }


    void Start()
    {
        foreach (Card card in cards)
        {
            cardRegister.Add(card.name, card);
        }
    }
}
