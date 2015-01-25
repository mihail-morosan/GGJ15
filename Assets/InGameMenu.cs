using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour
{

    public KeyCode KeyToInvokeMenu = KeyCode.Escape;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyToInvokeMenu))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
	}

    void OnGUI()
    {
        if (Time.timeScale == 0)
        {
            GUI.BeginGroup(new Rect(((Screen.width / 2) - (400 / 2)), ((Screen.height / 2) - (400 / 2)), 400, 400), "Options");

            if (GUI.Button(new Rect(0, 0, 300, 50), "Restart"))
            {
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevel);
                //AudioListener.pause = false;
            }

            if (GUI.Button(new Rect(0, 60, 300, 50), "Main Menu"))
            {
                Time.timeScale = 1;
                Application.LoadLevel("MainMenu");
                //AudioListener.pause = false;
            }
            if (GUI.Button(new Rect(0, 120, 300, 50), "Resume"))
            {
                //Application.LoadLevel(1);
                Time.timeScale = 1;
            }

            if (GUI.Button(new Rect(0, 180, 300, 50), "Quit Game"))
            {
                Application.Quit();
            }
            GUI.EndGroup();

            //AudioListener.pause = true;
        }
    }
}
