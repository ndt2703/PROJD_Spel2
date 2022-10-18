using System.Collections;
using System.Collections.Generic;
using System;

public class ResponsePlayCard : ServerResponse
{
    public Tuple<string, TargetInfo> cardToPlay = new Tuple<string, TargetInfo>("", new TargetInfo());

    public ResponsePlayCard()
    {
        Type = 10;
    }
    public ResponsePlayCard(Tuple<string, TargetInfo> cardToPlay)
    {
        Type = 10;

        this.cardToPlay = cardToPlay; 
    }
}
