using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSclaer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
    {
        GUI.DrawTextureWithTexCoords(
            new Rect(200, 200, 400, 250),
            (Resources.Load("Images/Vie") as Texture2D), new Rect(0, 0, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
