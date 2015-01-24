using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScoreScripts : MonoBehaviour
{
    public Text ScoreText;

	// Use this for initialization
	void Start () {
	}

    public void LoadScene(String scene)
    {
        Application.LoadLevel(scene); 
    }

	// Update is called once per frame
	void Update () {
        if (ScoreText != null)
        {
            ScoreText.text = "You are a winner! Or not. Your score is: " + ApplicationState.Score;
        }
	}
}
