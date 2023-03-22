using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public RequestType requestType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void CarPartPainted()
    {
        if(requestType == RequestType.Paint)
        currentAmount++;
    }
    public void CarPartCleaned()
    {
        if (requestType == RequestType.Clean)
            currentAmount++;
    }
    public void CarPartAssembled()
    {
        if(requestType == RequestType.Assemble)
            currentAmount++;
    }
}
public enum RequestType
{
    Paint,
    Clean,
    Assemble
}
