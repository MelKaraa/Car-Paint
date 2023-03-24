using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class QuestGoal 
{
    public RequestType requestType;

    public int paintedNeeded;
    [HideInInspector]
    public int paintedAmount;

    public int CleanedNeeded;
    [HideInInspector]
    public int CleanedAmount;

    public int AssembleNeeded;
    [HideInInspector]
    public int AssembledAmount;

    [SerializeField] TMP_Text paintedTxt;
    [SerializeField] TMP_Text cleanedTxt;
    [SerializeField] TMP_Text assembledTxt;
    
    public void Start()
    {
        if (requestType == RequestType.Paint)
            paintedTxt.text = paintedAmount + "/" + paintedNeeded;
        if (requestType == RequestType.Clean)
            cleanedTxt.text = CleanedAmount + "/" + CleanedNeeded;
        if (requestType == RequestType.Assemble)
            assembledTxt.text = AssembledAmount + "/" + AssembleNeeded;
    }
    public bool PaintIsReached()
    {
        return (paintedAmount >= paintedNeeded);
    }
    public bool CleanedIsReached()
    {
        return (CleanedAmount >= CleanedNeeded);
    }
    public bool AssembleIsReached()
    {
        return (AssembledAmount >= AssembleNeeded);
    }

    public void CarPartPainted()
    {
        if(requestType == RequestType.Paint)
            if(paintedAmount < paintedNeeded)
            paintedAmount++;
        paintedTxt.text = paintedAmount + "/" + paintedNeeded;
    }
    public void CarPartCleaned()
    {
        if (requestType == RequestType.Clean)
            if(CleanedAmount < CleanedNeeded)
            CleanedAmount++;
        cleanedTxt.text = CleanedAmount + "/" + CleanedNeeded;
    }
    public void CarPartAssembled()
    {
        if(requestType == RequestType.Assemble)
            if(AssembledAmount < AssembleNeeded)
            AssembledAmount++;
        assembledTxt.text = AssembledAmount + "/" + AssembleNeeded;
    }
}
public enum RequestType
{
    Paint,
    Clean,
    Assemble
}
