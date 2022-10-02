using System.Collections;
using System.Collections.Generic;
using System;

public class ServerResponse : MBJson.JSONDeserializeable,MBJson.JSONTypeConverter
{
  public  int Type;
  
  public  int whichPlayer;

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
