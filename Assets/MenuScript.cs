using UnityEngine;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {

	public void Restart()
    {
        GlobalVariables.restart = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OnGUI ()
    {
        if (GlobalVariables.menu)
        {
            float width = Screen.width;
            float height = Screen.height;
            //GUIContent bg = new GUIContent();
            GUIStyle bg = new GUIStyle(GUI.skin.box);
            bg.active.background = (Texture2D)Resources.Load("TransparentBackground");
            GUI.Box(new Rect(0,0,width,height), "", bg);

            GUIStyle replayButtonStyle = new GUIStyle(GUI.skin.button);

            replayButtonStyle.fontSize = Screen.width / 10;
            replayButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            replayButtonStyle.alignment = TextAnchor.MiddleCenter;
            
            replayButtonStyle.normal.background = (Texture2D)Resources.Load("green_button00");
            replayButtonStyle.hover.background = (Texture2D)Resources.Load("green_button00");

            if (GUI.Button(new Rect(width / 8, height / 2.5f, width*6/8, height / 6), "Replay", replayButtonStyle))
            {
                GlobalVariables.restart = true;
            }

            GUIStyle resetButtonStyle = new GUIStyle(GUI.skin.button);
            resetButtonStyle.fontSize = Screen.width / 10;
            resetButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            resetButtonStyle.alignment = TextAnchor.MiddleCenter;

            resetButtonStyle.normal.background = (Texture2D)Resources.Load("yellow_button00");
            resetButtonStyle.hover.background = (Texture2D)Resources.Load("yellow_button00");
            if (GUI.Button(new Rect(width / 8, (height / 3) + (height / 4), (width / 8) * 6, height / 8), "Reset Score", resetButtonStyle))
            {
                PlayerPrefs.SetInt("HighScore", 0);
            }

            GUIStyle exitButtonStyle = new GUIStyle(GUI.skin.button);
            exitButtonStyle.fontSize = Screen.width / 10;
            exitButtonStyle.font = (Font)Resources.Load("KOMIKAX_");
            exitButtonStyle.alignment = TextAnchor.MiddleCenter;

            exitButtonStyle.normal.background = (Texture2D)Resources.Load("red_button11");
            exitButtonStyle.hover.background = (Texture2D)Resources.Load("red_button11");

            if (GUI.Button(new Rect(width / 8, (height / 3) + height * 2/4, (width / 8) * 6, height / 8), "Exit", exitButtonStyle))
            {
                Application.Quit();
            }
        }
    }
}
