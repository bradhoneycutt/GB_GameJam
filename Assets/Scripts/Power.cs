using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

   // Tweakables
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    // Private variables
    private float progress; // barDisplay, renamed

    public void SetProgress(float relativeForce)
    {
        progress = relativeForce;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), emptyTex);
        GUI.Box(new Rect(pos.x, pos.y, size.x * progress, size.y), fullTex);
    }
}
