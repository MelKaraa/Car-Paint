using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;
    public static float Money;
    public static bool isPainting;

    // Start is called before the first frame update
    void Start()
    {
        Money = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Money < 100 && !isPainting)
        {
            GameOver = true;
        }
    }
}
