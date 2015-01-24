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
	
	// Update is called once per frame
	void Update ()
	{
	    if (ScoreText == null)
	        return;
	    ScoreText.text = "Score: " + Score;
	}
}
