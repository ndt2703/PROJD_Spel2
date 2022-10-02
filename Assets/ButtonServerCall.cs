using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonServerCall : MonoBehaviour
{
    public TestInternet testINternet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCardOnBoard()
    {
        testINternet.sendRequest(new ClientRequest());

    }
}
