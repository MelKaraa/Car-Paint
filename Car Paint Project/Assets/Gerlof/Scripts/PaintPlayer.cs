using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaintPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem paintParticle;
    [SerializeField] float ammoAddMultiplier;
    [SerializeField] float ammoUseMultiplier;
    public static bool spray;
    [SerializeField] Material paintFill;
    [SerializeField] GameObject glass;
    Renderer rend;

    public Color[] colors;

    float moneyPercent;
    public void Spray()
    {
        spray = !spray;
        //rend = glass.GetComponent<Renderer>();
        //paintFill = rend.material;
        paintFill.SetColor("_LiquidColor", colors[QuestSystem.colorIndex]);
        //paintFill.color = colors[QuestSystem.colorIndex];
    }

    private void Update()
    {
        
        float singlePer = GameManager.Money / 100;
        float total = 1000f;
        float current = GameManager.Money;
        float percent = current / total;
        percent *= 100f;
        moneyPercent = singlePer *= percent;
        moneyPercent /= 500f;
        moneyPercent /= 7f;
        //Debug.Log(moneyPercent.ToString());
        if (spray)
        {
            paintFill.SetFloat("_Fill", moneyPercent);
            paintParticle.Emit(300);
            GameManager.Money -= ammoUseMultiplier * Time.deltaTime;
        }
        else
        {
            paintParticle.Stop();
        }
    }
}
