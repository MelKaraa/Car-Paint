using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanSpray : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform shootPos;
    public Color[] colors;
    public float progressSpeed;

    public float paintDstTreshold;
    public LayerMask whatIsPaintable;

    Mesh CloneMesh(Mesh aMat)
    {
        return Instantiate(aMat);
    }
    void Awake()
    {
        MeshFilter[] filters = FindObjectsOfType<MeshFilter>();
        for (int i = 0; i < filters.Length; i++)
        {
            if (filters[i].gameObject.layer != LayerMask.NameToLayer("Paint")) continue; // ==> Verander paintable naar de naam van je paint layer

            var mesh = filters[i].sharedMesh;

            mesh = CloneMesh(mesh);
            mesh.name = mesh.name + filters[i].transform.name;

            filters[i].sharedMesh = mesh;
        }
    }

    void Update()
    {

        if (PaintPlayer.spray)
        {
            // ==> Raycast vanuit de spray painter
            if (Physics.Raycast(shootPos.position, shootPos.forward, out RaycastHit hit, 100000f))
            {
                // ==> Overlap sphere gebruiken, als we op een hoek van een mesh sprayen, worden ook andere paintable meshes gepaint
                var colliders = Physics.OverlapSphere(hit.point, paintDstTreshold * 2, whatIsPaintable);

                for (int j = 0; j < colliders.Length; j++)
                {
                    MeshCollider collider = colliders[j].GetComponent<MeshCollider>();

                    if (collider == null) continue;

                    Mesh mesh = collider.GetComponent<MeshFilter>().sharedMesh;

                    if (mesh) // ==> kijk of er een mesh is
                    {
                        var colors = mesh.colors;

                        // ==> checken of de meshColors array dezelfde length heeft als de vertices, zodat ze juist gepaint kunnen worden
                        if (colors.Length != mesh.vertices.Length)
                        {
                            colors = new Color[mesh.vertices.Length];

                            // ==> Niet dezelfde length? De color array wordt gemaakt met een basiskleur
                            for (int i = 0; i < colors.Length; i++)
                            {
                                colors[i] = Color.white;
                            }
                        }
                        var transform = collider.transform;

                        var vertices = mesh.vertices;

                        // ==> Voor elke vertex kijken of die in de spray zone ligt van de spray gun
                        for (int i = 0; i < vertices.Length; i++)
                        {
                            // ==> Convert vertex positie naar world pos
                            Vector3 vertexWorldPos = transform.TransformPoint(vertices[i]);

                            float dst = Vector3.Distance(vertexWorldPos, hit.point);

                            if (dst <= paintDstTreshold)
                            {
                                // ==> de intensiteit van het sprayen wordt bepaalt op basis van de spray zone
                                float factor = Mathf.InverseLerp(0, paintDstTreshold, dst);
                                colors[i] = Color.Lerp(colors[i], this.colors[QuestSystem.colorIndex], progressSpeed * factor * Time.fixedDeltaTime); // ==> lerpen gebruiken om het smooth te painter
                            }
                        }

                        mesh.colors = colors;
                    }
                }

            }
        }
        
    }
}
