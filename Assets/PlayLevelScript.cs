using System;
using UnityEngine;
using System.Collections;

public class PlayLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(String level)
    {
        Application.LoadLevel(level);
    }
}
