using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenManager : MonoBehaviour
{

    public static bool drawingOnSurface = false;
    public static bool drawingWithHand = false;

    public void DrawOnSurface()
    {
        drawingOnSurface = true;
        drawingWithHand = false;
    }
    public void DrawInSpace()
    {
        drawingOnSurface = false;
        drawingWithHand = false;
    }
    public void DrawWithHand()
    {
        drawingOnSurface = false;
        drawingWithHand = true;
    }
}
