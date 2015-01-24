using System;
using UnityEngine;
using System.Collections;

public class TimerGUI : MonoBehaviour {

    private float startTime;

    private int restSeconds;

    private int roundedRestSeconds;

    private float displaySeconds;

    private float displayMinutes;

    public int CountDownSeconds;

    void Awake() { startTime = Time.time; }

    void OnGUI()
    { 
        float guiTime = Time.time - startTime;

        restSeconds = CountDownSeconds - (int)(guiTime);

        //display messages or whatever here --&gt;do stuff based on your timer
        if (restSeconds == 60)
        {
            print("One Minute Left");
        }
        if (restSeconds == 0)
        {
            print("Time is Over");
            //do stuff here
        }

        //display the timer
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = roundedRestSeconds / 60;

        String text = String.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
        GUI.Label(new Rect(400, 25, 100, 30), text);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
