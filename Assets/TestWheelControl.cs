using UnityEngine;
using System.Collections;

public class TestWheelControl : MonoBehaviour
{

    public Vector3 Velocity;

    public bool[] IsAlwaysOn;

    public float VelocityMagnitude;

	// Use this for initialization
	void Start () {
        rigidbody.centerOfMass = new Vector3(0, -0.5f, 0.3f);
	}

    Rigidbody GetJoint(int n)
    {
        return this.transform.GetChild(n).GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        Vector3[] Vel = new Vector3[4];

        if (Input.GetKey(KeyCode.Q) || IsAlwaysOn[0])
        {
            Vel[0].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vel[0].z -= VelocityMagnitude * (IsAlwaysOn[0] ? 2 : 1);
        }
        if (Input.GetKey(KeyCode.W) || IsAlwaysOn[1])
        {
            Vel[1].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vel[1].z -= VelocityMagnitude * (IsAlwaysOn[1] ? 2 : 1);
        }
        if (Input.GetKey(KeyCode.E) || IsAlwaysOn[2])
        {
            Vel[2].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vel[2].z -= VelocityMagnitude * (IsAlwaysOn[2] ? 2 : 1);
        }
        if (Input.GetKey(KeyCode.R) || IsAlwaysOn[3])
        {
            Vel[3].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vel[3].z -= VelocityMagnitude * (IsAlwaysOn[3] ? 2 : 1);
        }

	    for (int i = 0; i < 4; i++)
	    {
            GetCollider(i).motorTorque = Vel[i].z;

	        if (Vel[i].z == 0)
	        {
	            GetCollider(i).brakeTorque = VelocityMagnitude/10;
	        }

            GetCollider(i).steerAngle = 0;
	    }

	    for (int i = 0; i < 4; i++)
	    {
	        if (Vel[i].z != Vel[3 - i].z)
	        {
	            if (i < 3 - i)
	            {
	                GetCollider(i).steerAngle = 35;

	            }
	            else
	            {

                    GetCollider(i).steerAngle = -35;
	            }
	        }
	    }
	}

    WheelCollider GetCollider(int n)
    {
        return this.transform.GetChild(4 + n).GetComponent<WheelCollider>();
    }

    MeshRenderer GetRenderer(int n)
    {
        return this.transform.GetChild(n).GetComponent<MeshRenderer>();
    }
}
