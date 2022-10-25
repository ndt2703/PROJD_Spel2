using System;
using System.Collections;
using System.Collections.Generic;


public class TargetInfo : MBJson.JSONDeserializeable, MBJson.JSONTypeConverter
{   
    public ListEnum whichList = ListEnum.myGraveyard;
    public int index = 0;

    public TargetInfo(){}

    public TargetInfo(ListEnum list, int index)
    {
        whichList = list;
        this.index = index;
    }
    public object Deserialize(MBJson.JSONObject ObjectToParse)
    {
        object ReturnValue = new MBJson.DynamicJSONDeserializer(this).Deserialize(ObjectToParse);
        return (ReturnValue);
    }
    public Type GetType(int integerToConvert)
    {
        return typeof(TargetInfo); 
    }
}
