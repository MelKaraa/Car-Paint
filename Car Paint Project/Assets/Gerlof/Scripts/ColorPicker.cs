using UnityEngine;
public class ColorPicker : MonoBehaviour
{ 
    public void SetPaintColor(int index)
    {
        QuestSystem.colorIndex = index;
    }
}