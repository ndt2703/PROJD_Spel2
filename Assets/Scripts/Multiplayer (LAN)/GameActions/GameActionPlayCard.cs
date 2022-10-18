using System.Collections;
using System.Collections.Generic;
using System;

public class GameActionPlayCard : GameAction
{
    public Tuple<string, TargetInfo> cardToPlay = new Tuple<string, TargetInfo>("", new TargetInfo());

    public GameActionPlayCard()
    {
        Type = 11; 
    }
    public GameActionPlayCard(Tuple<string, TargetInfo> cardToPlay)
    {
        Type = 11;

        this.cardToPlay = cardToPlay;
    }
}
