using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaintPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem paintParticle;
    [SerializeField] float ammoAddMultiplier;
    [SerializeField] float ammoUseMultiplier;
    [SerializeField] bool spray;

    [SerializeField] TMP_Text ammoTxt;

    public void Spray()
    {
        spray = !spray;
    }

    private void Update()
    {
        if (GameManager.Money <= 0)
        {
            ammoTxt.text = "Money: 0";
            return;
        }
        if (spray)
        {
            paintParticle.Emit(10);
            GameManager.Money -= ammoUseMultiplier * Time.deltaTime;
            ammoTxt.text = "Money: " + GameManager.Money.ToString("F0");
        }
        else
        {
            paintParticle.Stop();
        }
    }
}
