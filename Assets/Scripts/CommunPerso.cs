using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CommunPerso : MonoBehaviour
{
    // Start is called before the first frame update
    public static int life1 = 5;
    public static int life2 = 5;
    public static bool canMove = true;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GUIStyle GetStyleOfLabel()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.alignment = (TextAnchor)TextAlignment.Center;
        guiStyle.fontSize = 24;
        guiStyle.fontStyle = FontStyle.Italic;
        guiStyle.normal.textColor = Color.white;

        return guiStyle;
    }

    public static void SetWinnerText(string namePerso)
    {
        GUI.Label(new Rect(100, 100, Screen.width - 100, 20), "Le gagnant est " + namePerso + " !", GetStyleOfLabel());
    }

}
