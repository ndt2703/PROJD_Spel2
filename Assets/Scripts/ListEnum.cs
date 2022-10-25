using System;
using System.Collections;
using System.Collections.Generic;

public class ListEnum : MBJson.JSONDeserializeable, MBJson.JSONTypeConverter
{
   

    public bool myGraveyard = false; 
    public bool opponentGraveyard = false; 
    public bool myLandmarks = false; 
    public bool opponentLandmarks = false; 
    public bool myChampions = false; 
    public bool opponentChampions = false;


    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }
    public Type GetType(int integerToConvert)
    {
        return typeof(ListEnum);
    }
}
