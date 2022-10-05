using System.Collections;
using System.Collections.Generic;
using System;

public class GameAction : MBJson.JSONDeserializeable, MBJson.JSONTypeConverter
{

   public int Type = 0;
   
   public int cardId = 0;
   
   public bool cardPlayed = false;

    public Type GetType(int IntegerToConvert)
    {
        return (typeof(ServerResponse));
    }
    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }


}
