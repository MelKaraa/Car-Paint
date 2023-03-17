using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    public Color paintColor;
    public float paintAmount = 1.0f;
    public float paintRadius = 0.1f;


    void Start()
    {
        
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray;
        if(Physics.Raycast(ray, out hit))
        {
            if (PaintPlayer.spray)
            {

            }
        }
    }



}