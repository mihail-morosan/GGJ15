using UnityEngine;
using System.Collections;

public class WheelControl : MonoBehaviour
{
    public KeyCode ForwardKey;
    public KeyCode BackwardKey;

    public Color DefaultColor = Color.black;
    public Color ForwardColor = Color.green;
    public Color BackwardColor = Color.red;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.renderer.material.color = DefaultColor;
	    if (Input.GetKey(ForwardKey))
	    {
	        this.renderer.material.color = ForwardColor;
	    }

	    if (Input.GetKey(BackwardKey))
	    {
            this.renderer.material.color = BackwardColor;
	    }

	    if (Input.GetKey(ForwardKey) && Input.GetKey(BackwardKey))
	    {
            this.renderer.material.color = DefaultColor;
	    }
	}
}
