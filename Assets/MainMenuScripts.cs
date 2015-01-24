using System;
using UnityEngine;
using System.Collections;

public class MainMenuScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(String scene)
    {
        Application.LoadLevel(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
