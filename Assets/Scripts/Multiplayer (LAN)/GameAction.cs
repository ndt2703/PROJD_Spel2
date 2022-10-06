using System.Collections;
using System.Collections.Generic;
using System;

public class GameAction : MBJson.JSONDeserializeable, MBJson.JSONTypeConverter
{

   public int Type = 0;
   
   public int cardId = 0;
   
   public bool cardPlayed = false;



    public GameAction() { }// denna far inte tas bort, kravs for parsingen 
    public Type GetType(int IntegerToConvert)
    {
        return (typeof(GameAction));
    }
    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }


}
