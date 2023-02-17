using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    public Color sprayPaintColor; // The color to apply to the object

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[particleSystem.GetSafeCollisionEventSize()];
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        Renderer renderer = other.GetComponent<Renderer>();
        Material[] materials = renderer.materials;

        for (int i = 0; i < numCollisionEvents; i++)
        {
            Vector3 collisionPoint = collisionEvents[i].intersection;
            int materialIndex = collisionEvents[i].triangleIndex;
            Material material = materials[materialIndex];
            material.color = sprayPaintColor;
        }
    }
}