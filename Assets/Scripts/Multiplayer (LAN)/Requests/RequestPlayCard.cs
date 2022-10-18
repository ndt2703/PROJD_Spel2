using System.Collections;
using System.Collections.Generic;
using System;

public class RequestPlayCard : ClientRequest
{
    public Tuple<string, TargetInfo> cardToPlay = new Tuple<string, TargetInfo>("", new TargetInfo());


    public RequestPlayCard()
    {
        Type = 11; 
    }
    public RequestPlayCard(Tuple<string, TargetInfo> cardToPlay)
    {
        Type = 11;
        this.cardToPlay = cardToPlay; 
    }

}
