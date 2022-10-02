using System;
using System.Collections;
using System.Collections.Generic;

public class ClientRequest : MBJson.JSONDeserializeable,MBJson.JSONTypeConverter
{
    public  int type = -1; 
    public  int whichPlayer = -1;

    public bool createScene = false;

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
