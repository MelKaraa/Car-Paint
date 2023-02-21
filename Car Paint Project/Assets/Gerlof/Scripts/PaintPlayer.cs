using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaintPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem paintParticle;
    [SerializeField] float ammoAddMultiplier;
    [SerializeField] float ammoUseMultiplier;
    bool spray;
    float paintAmmo = 50;

    [SerializeField] TMP_Text ammoTxt;

    public void Spray()
    {
        spray = !spray;
    }

    private void Update()
    {
        if (paintAmmo >= 100)
        {
            paintAmmo = 100;
            ammoTxt.text = "Paint: " + paintAmmo.ToString("F0");
            return;
        }
        else
        {
            paintAmmo += Time.deltaTime * ammoAddMultiplier;
        }
        if (spray && paintAmmo > 0)
        {
            paintParticle.Play();
            paintAmmo -= Time.deltaTime * ammoUseMultiplier;
        }
        else
        {
            paintParticle.Stop();
        }
        ammoTxt.text = "Paint: " + paintAmmo.ToString("F0");
    }
}
