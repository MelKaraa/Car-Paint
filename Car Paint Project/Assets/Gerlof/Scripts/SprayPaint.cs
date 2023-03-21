using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    [Header("Settings")]
    public Color[] colors = new Color[0];
    public float paintRadius = 0.1f;

    public Mesh curMesh;
    
    [SerializeField]private int colorIndex;
    private Vector3[] verts;
    RaycastHit hit;
    void Start()
    {
        
    }

    private void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit))
        {
          
            if (hit.transform.GetComponent<MeshFilter>().GetComponent<Mesh>())
            {
                curMesh = hit.transform.GetComponent<MeshFilter>().GetComponent<Mesh>();
                verts = curMesh.vertices;
                if (PaintPlayer.spray)
                {
                    PaintCar(curMesh, hit.triangleIndex, colors[colorIndex]);
                }
            }
            else
            {
                Debug.Log("No mesh found");
                curMesh = hit.transform.GetComponent<MeshFilter>().GetComponent<Mesh>();
            }
            
        }
    }

    void PaintCar(Mesh mesh, int i, Color color)
    {
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[0];

        if (mesh.colors.Length > 0)
        {
            colors = mesh.colors;
        }
        else
        {
            colors = new Color[vertices.Length];
        }

        int[] triangles = mesh.triangles;
        for (int t = 0; t < triangles.Length; t++)
        {
            if (triangles[t] == i) // closest vertex i
            {
                int subIndex = t % 3;
                if (subIndex == 0)
                {
                    // apply color to t+1 & t+2
                    colors[t + 1] = color;
                    colors[t + 2] = color;
                }
                else if (subIndex == 1)
                {
                    // apply color to t-1 and t+1
                    colors[t - 1] = color;
                    colors[t + 1] = color;
                }
                else
                {
                    // apply color to t-2 & t-1
                    colors[t - 2] = color;
                    colors[t - 1] = color;
                }
            }
        }
        mesh.colors = colors;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, hit.point);
    }
}