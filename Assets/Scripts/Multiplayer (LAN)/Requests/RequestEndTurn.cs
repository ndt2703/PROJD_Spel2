using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestEndTurn : ClientRequest
{   
    public RequestEndTurn() { } // maste vara kvar

    public RequestEndTurn(int whichPlayer)
    {
        this.whichPlayer = whichPlayer;

        Type = 2; 
    }
}
