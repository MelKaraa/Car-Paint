using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem paintParticle;

    bool spray;
    public void Spray()
    {
        spray = !spray;
    }

    private void Update()
    {
        if(spray)
        {
            paintParticle.Play();
        }
        else
        {
            paintParticle.Stop();
        }
    }
}
