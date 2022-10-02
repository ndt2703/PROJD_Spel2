using System.Collections;
using System.Collections.Generic;
using System;

public class ServerResponse : MBJson.JSONDeserializeable,MBJson.JSONTypeConverter
{
  public  int type;
  
  public  int whichPlayer;

    public Type GetType(int IntegerToConvert)
    {
        return (typeof(ClientRequest));
    }
    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }
}
