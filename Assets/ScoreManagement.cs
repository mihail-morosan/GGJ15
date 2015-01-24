using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{

    public int Score
    {
        get { return ApplicationState.Score; }
        set { ApplicationState.Score = value; }
    }

    public Text ScoreText;

    private float startTime;

    private int restSeconds;

    private int roundedRestSeconds;

    private float displaySeconds;

    private float displayMinutes;

    private String _text;
    
    public int CountDownSeconds;

    public String LevelToLoadOnComplete;

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
            //print("Time is Over");
            //do stuff here

            if (LevelToLoadOnComplete.Length > 0)
                Application.LoadLevel(LevelToLoadOnComplete);
        }

        //display the timer
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = roundedRestSeconds / 60;

        _text = String.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
        //GUI.Label(new Rect(400, 25, 100, 30), text);

    }

	// Use this for initialization
	void Start ()
	{
	    ApplicationState.ResetScore();
	}

    public void AddPoints(int Value)
    {
        Debug.Log(Score + " " + Value);
        Score = Score + Value;
    }

    public void AddSeconds(int Value)
    {
        CountDownSeconds += Value;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (ScoreText == null)
            return;

	    ScoreText.text = "Score: " + Score + ". Time left: " + _text;
	}
}
