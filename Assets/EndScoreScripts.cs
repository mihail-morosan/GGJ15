using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScoreScripts : MonoBehaviour
{
    public Text ScoreText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreText != null)
        {
            ScoreText.text = "You are a winner! Or not. Your score is: " + ApplicationState.Score;
        }
	}
}
