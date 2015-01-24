using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{

    public int Score;

    public Text ScoreText;

	// Use this for initialization
	void Start ()
	{
	    Score = 0;
	}

    public void AddPoints(int Value)
    {
        Score += Value;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (ScoreText == null)
	        return;
	    ScoreText.text = "Score: " + Score;
	}
}
