using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    public Quest quest;
    public GameManager gameManager;

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
    [SerializeField] TMP_Text activeRewardText;
    [SerializeField] Image colorImage;
    [SerializeField] Image colorFill;

    
    int colorIndex;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        rollsTxt.text = "Re-rolls left:" + "\n" + reRolls;
    }

    public void OpenRequest()
    {
        if (reRolls <= 0)
        {
            noReRollsUI.SetActive(true);
            return;
        }
        colorIndex = Random.Range(0, 9);
        colorTxt.text = quest.color[colorIndex];
        rewardTxt.text = quest.reward.ToString();
        quest.colorImage.color = quest.colors[colorIndex];
        quest.colorFill.color = quest.colors[colorIndex];
        reRolls--;
        rollsTxt.text = "Re-rolls left:" + "\n" + reRolls;
        requestUI.SetActive(true);
    }

    public void AcceptRequest()
    {
        requestUI.SetActive(false);
        quest.isActive = true;
        gameManager.activeRequest = quest;

        newRequestUI.SetActive(false);

        activeColorTxt.text = colorTxt.text;
        activeRewardText.text = rewardTxt.text;
        colorImage.color = quest.colors[colorIndex];
        colorFill.color = quest.colors[colorIndex];
        activeRequestUI.SetActive(true);
    }

    public void PaintCarPart()
    {
        if(quest.isActive)
        {
            quest.goal.CarPartPainted();
            if (quest.goal.IsReached())
            {
                GameManager.Money += quest.reward;
                quest.Complete();
            }
        }
    }

    public void CleanCarPart()
    {
        if (quest.isActive)
        {
            quest.goal.CarPartCleaned();
            if (quest.goal.IsReached())
            {
                GameManager.Money += quest.reward;
                quest.Complete();
            }
        }
    }

    public void CarPartAssembled()
    {
        if (quest.isActive)
        {
            quest.goal.CarPartAssembled();
            if (quest.goal.IsReached())
            {
                GameManager.Money += quest.reward;
                quest.Complete();
            }
        }
    }
}
