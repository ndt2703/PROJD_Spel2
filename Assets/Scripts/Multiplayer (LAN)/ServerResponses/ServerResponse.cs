using System.Collections;
using System.Collections.Generic;
using System;

public class ServerResponse : MBJson.JSONDeserializeable,MBJson.JSONTypeConverter
{
    public  int Type = 0;
  
    public  int whichPlayer = 100;

    public bool cardPlayed = false;

    public List<GameAction> OpponentActions = new List<GameAction>();

    public string message = "";

    public int cardId  = 0; 

    public Type GetType(int IntegerToConvert)
    {   if(Type == 0)
        {
            return (typeof(ServerResponse));
        }
        if (Type == 1)
        {
            return (typeof(ResponseEndTurn));
        }
        return (typeof(ServerResponse));
    }
    public ServerResponse() { } //Denna ska inte tas bort, behovs for parsingen 

    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }
}
