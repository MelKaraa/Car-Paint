using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    public Color paintColor;
    public float paintAmount = 1.0f;
    public float paintRadius = 0.1f;

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        MeshCollider meshCollider = other.GetComponent<MeshCollider>();

        if (meshCollider == null || !meshCollider.enabled)
            return;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.main.maxParticles];
        int numParticles = ps.GetParticles(particles);

        for (int i = 0; i < numParticles; i++)
        {
            Vector3 particlePosition = particles[i].position;
            Vector3 particleDirection = particles[i].velocity.normalized;

            RaycastHit hit;

            if (meshCollider.Raycast(new Ray(particlePosition - particleDirection * 0.01f, particleDirection), out hit, paintRadius))
            {
                Mesh mesh = hit.collider.GetComponent<MeshFilter>().mesh;

                int[] triangles = mesh.triangles;
                Vector3[] vertices = mesh.vertices;

                int triangleIndex = hit.triangleIndex;

                Vector3 p0 = vertices[triangles[triangleIndex * 3]];
                Vector3 p1 = vertices[triangles[triangleIndex * 3 + 1]];
                Vector3 p2 = vertices[triangles[triangleIndex * 3 + 2]];

                Vector3 barycentricCoord = hit.barycentricCoordinate;

                Vector3 hitPoint = p0 * barycentricCoord.x + p1 * barycentricCoord.y + p2 * barycentricCoord.z;

                MeshRenderer meshRenderer = hit.collider.GetComponent<MeshRenderer>();

                Texture2D tex = (Texture2D)meshRenderer.material.mainTexture;

                Vector2 pixelUV = hit.textureCoord;

                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                Color[] colors = tex.GetPixels(Mathf.FloorToInt(pixelUV.x - paintRadius), Mathf.FloorToInt(pixelUV.y - paintRadius), Mathf.CeilToInt(paintRadius * 2), Mathf.CeilToInt(paintRadius * 2));

                for (int j = 0; j < colors.Length; j++)
                {
                    colors[j] = Color.Lerp(colors[j], paintColor, paintAmount);
                }

                tex.SetPixels(Mathf.FloorToInt(pixelUV.x - paintRadius), Mathf.FloorToInt(pixelUV.y - paintRadius), Mathf.CeilToInt(paintRadius * 2), Mathf.CeilToInt(paintRadius * 2), colors);

                tex.Apply();
            }
        }
    }
}