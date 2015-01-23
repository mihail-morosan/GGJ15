using UnityEngine;
using System.Collections;

public class WheelControl : MonoBehaviour
{

    public float Torque = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.GetComponent<Rigidbody>().AddTorque(Torque,0,0);
	}
}
