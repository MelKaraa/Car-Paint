using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    [Header("Settings")]
    public Color[] colors;

    public Mesh curMesh;
    
    [SerializeField]private int colorIndex;
    RaycastHit hit;

    private void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit))
        {

            Mesh mesh = hit.transform.GetComponent<MeshFilter>().mesh;
            if (mesh)
            {
                curMesh = mesh;
                if (PaintPlayer.spray)
                {
                    PaintCar(curMesh, hit.triangleIndex, colors[colorIndex]);
                }
            }
            else
            {
                Debug.Log("No mesh found, check if the Read/Write is enabled!");
            }
            
        }
    }

    public void PaintCar(Mesh mesh, int i, Color color)
    {
        Vector3[] vertices = mesh.vertices;
        Color[] colors = mesh.colors;

        Debug.Log(colors.Length);

        if (colors.Length < 1)
        {
            colors = new Color[vertices.Length];
            for (int j = 0; j < colors.Length; j++)
            {
                colors[j] = Color.blue;
            }
        }

        //Color[] colors = new Color[vertices.Length];



        int[] triangles = mesh.triangles;
        for (int t = 0; t < triangles.Length; t++)
        {
            if (triangles[t] == i) // closest vertex i
            {

                Debug.Log("Colors: " + colors.Length + ", t: " + t);
                //Debug.Log("t:" + t);
                //Debug.Log(colors[t]);

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