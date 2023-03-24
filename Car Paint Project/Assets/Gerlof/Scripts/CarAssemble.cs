using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAssemble : MonoBehaviour
{
    GameObject carPart;
    [SerializeField] GameObject snapPos;
    [SerializeField] float snapDistance = 5f;
    public static bool canSnap;
    public bool isPaintable;
    private QuestSystem questSystem;

    private void Start()
    {
        questSystem = GameObject.Find("GameManager").GetComponent<QuestSystem>();
        carPart = gameObject;
        if (isPaintable)
        {
            questSystem.quests.goal[0].paintedNeeded++;
        }
        questSystem.quests.goal[2].AssembleNeeded++;
    }
    void Update()
    {
        if(Vector3.Distance(carPart.transform.position, snapPos.transform.position) < snapDistance && canSnap)
        {
            carPart.transform.position = snapPos.transform.position;
            carPart.transform.rotation = snapPos.transform.rotation;
        }
    }
}
