using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GlobalVariables.score = 0;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
	}

	void Update () {
        GlobalVariables.boxForce = 200f + GlobalVariables.score * 5;

            if (GlobalVariables.score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", GlobalVariables.score);
            }
	}

    public Font font;
    void OnGUI ()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = Screen.height / 12;
        style.alignment = TextAnchor.UpperCenter;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 25, 100, 100), Convert.ToString(GlobalVariables.score) + " / " + Convert.ToString(PlayerPrefs.GetInt("HighScore")), style);
    }
}
