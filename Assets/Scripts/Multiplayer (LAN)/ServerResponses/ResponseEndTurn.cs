using System.Collections;
using System.Collections.Generic;

public class ResponseEndTurn : ServerResponse
{
    
    public ResponseEndTurn() {
        Type = 1; 
    } // ta ej bort
    public ResponseEndTurn(int whichPlayer)
    {
        Type = 1;
        this.whichPlayer = whichPlayer; 
    }
}
