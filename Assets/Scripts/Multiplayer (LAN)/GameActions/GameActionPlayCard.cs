using System.Collections;
using System.Collections.Generic;
using System;

public class GameActionPlayCard : GameAction
{
    public Tuple<string, TargetInfo> cardToPlay = new Tuple<string, TargetInfo>("", new TargetInfo());

    public GameActionPlayCard()
    {
        Type = 10; 
    }
    public GameActionPlayCard(Tuple<string, TargetInfo> cardToPlay)
    {
        Type = 10;

        this.cardToPlay = cardToPlay;
    }
}
