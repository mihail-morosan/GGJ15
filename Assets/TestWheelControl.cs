using UnityEngine;
using System.Collections;

public class TestWheelControl : MonoBehaviour
{

    public Vector3 Velocity;

    public bool Input1, Input2, Input3, Input4;

    public Vector3 Wheel1, Wheel2, Wheel3, Wheel4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 Vel1, Vel2, Vel3, Vel4;

        Vel1 = new Vector3(0, 0, 5);
        Vel2 = new Vector3(0, 0, 5);
        Vel3 = new Vector3(0, 0, 5);
        Vel4 = new Vector3(0, 0, 5);

	    if (Input1)
	        Vel1 *= -1;
	    if (Input2)
            Vel2 *= -1;
        if (Input3)
            Vel3 *= -1;
        if (Input4)
            Vel4 *= -1;


        this.GetComponent<Rigidbody>().AddForceAtPosition(Vel1, Wheel1);
        this.GetComponent<Rigidbody>().AddForceAtPosition(Vel2, Wheel2);
        this.GetComponent<Rigidbody>().AddForceAtPosition(Vel3, Wheel3);
        this.GetComponent<Rigidbody>().AddForceAtPosition(Vel4, Wheel4);

	}
}
