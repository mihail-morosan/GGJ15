using UnityEngine;
using System.Collections;

public class TestWheelControl : MonoBehaviour
{

    public Vector3 Velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.GetComponent<Rigidbody>().AddForce(Velocity);
	}
}
