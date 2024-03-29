using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    public Quest quests;
    public GameManager gameManager;

    [SerializeField] TMP_Text money;

    [Header("Request UI")]
    [SerializeField] GameObject requestUI;
    [SerializeField] TMP_Text colorTxt;
    [SerializeField] TMP_Text rewardTxt;

    [Header("New Request UI")]
    [SerializeField] GameObject newRequestUI;
    [SerializeField] int reRolls;
    [SerializeField] TMP_Text rollsTxt;
    [SerializeField] GameObject noReRollsUI;

    [Header("Active Request UI")]
    [SerializeField] GameObject activeRequestUI;
    [SerializeField] TMP_Text activeColorTxt;
    [SerializeField] Image colorImage;
    [SerializeField] Image colorFill;
    [SerializeField] GameObject glassFill;
    [SerializeField] GameObject sprayParticle;
    Renderer sprayRend;
    Renderer rend;
    
    public static int colorIndex;

    [Header("Completed Goals")]
    [SerializeField] bool PaintDone;
    [SerializeField] bool CleanDone;
    [SerializeField] bool AssembleDone;
    [SerializeField] Image paintUX;
    [SerializeField] Image cleanUX;
    [SerializeField] Image assembleUX;
    bool Goalsreached;
    [SerializeField] WaypointSystem waypointSystem;
    [SerializeField] CarSpawner carSpawner;
    
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        rollsTxt.text = "Re-rolls left:" + "\n" + reRolls;
        quests.goal[0].Start();
        quests.goal[1].Start();
        quests.goal[2].Start();
    }

    private void Update()
    {
        money.text = "Money: " + GameManager.Money.ToString("f0");
        if(PaintDone && CleanDone && AssembleDone && !Goalsreached)
        {
            Goalsreached = true;
            quests.Complete();
            reRolls = 3;
        }//UX Color Changing
        else
        {
            if (PaintDone)
            {
                paintUX.color = Color.green;
            }
            else
            {
                paintUX.color = Color.red;
            }
            if (CleanDone)
            {
                cleanUX.color = Color.green;
            }
            else
            {
                cleanUX.color = Color.red;
            }
            if (AssembleDone)
            {
                assembleUX.color = Color.green;
            }
            else
            {
                assembleUX.color = Color.red;
            }
            if (quests.goal[0].PaintIsReached())
            {
                PaintDone = true;
            }
            if (quests.goal[1].CleanedIsReached())
            {
                CleanDone = true;
            }
            if (quests.goal[2].AssembleIsReached())
            {
                AssembleDone = true;
            }
        } 
    }
    public void OpenRequest()
    {
        quests.goal[0].paintedNeeded = 0;
        quests.goal[1].CleanedNeeded = 0;
        quests.goal[2].AssembleNeeded = 0;
        if (reRolls <= 0)
        {
            noReRollsUI.SetActive(true);
            return;
        }
        colorIndex = Random.Range(0, quests.colors.Length);
        colorTxt.text = quests.color[colorIndex];
        rewardTxt.text = quests.reward.ToString();
        quests.colorImage.color = quests.colors[colorIndex];
        quests.colorFill.color = quests.colors[colorIndex];
        reRolls--;
        rollsTxt.text = "Re-rolls left:" + "\n" + reRolls;
        requestUI.SetActive(true);
    }

    public void AcceptRequest()
    {           
        gameManager.activeRequests.Add(quests);
        
        requestUI.SetActive(false);
        quests.isActive = true;
        
        newRequestUI.SetActive(false);

        activeColorTxt.text = colorTxt.text;
        colorImage.color = quests.colors[colorIndex];
        colorFill.color = quests.colors[colorIndex];
        activeRequestUI.SetActive(true);

        carSpawner.SpawnCar();
        waypointSystem = CarSpawner.currentCar.GetComponent<WaypointSystem>();
        rend = glassFill.GetComponent<Renderer>();
        rend.material.SetColor("_LiquidColor", quests.colors[QuestSystem.colorIndex]);
        rend.material.SetColor("_SurfaceColor", quests.colors[QuestSystem.colorIndex]);
        sprayRend = sprayParticle.GetComponent<Renderer>();
        sprayRend.material.color = quests.colors[QuestSystem.colorIndex];
    }

    public void PaintCarPart()
    {
        if(quests.isActive)
        {
            quests.goal[0].CarPartPainted();
        }
    }

    public void CleanCarPart()
    {
        if (quests.isActive)
        {
            quests.goal[1].CarPartCleaned();
        }
    }

    public void CarPartAssembled()
    {
        if (quests.isActive)
        {
            quests.goal[2].CarPartAssembled();            
        }
    }

    public void CompleteRequest()
    {
        float newReward = quests.reward / 100;
        float total = quests.goal[0].paintedNeeded + quests.goal[1].CleanedNeeded + quests.goal[2].AssembleNeeded;  
        float completed = quests.goal[0].paintedAmount + quests.goal[1].CleanedAmount + quests.goal[2].AssembledAmount;
        float percent = completed / total;
        percent *= 100f;
        Debug.Log("Percent of total gained: " + percent);
        newReward *= percent;
        GameManager.Money += newReward;
        Debug.Log("Money gained: " + newReward);

        waypointSystem.end = false;
        

        activeRequestUI.SetActive(false);
        newRequestUI.SetActive(true);
        reRolls = 3;
    }
}
