using UnityEngine;
using System.Collections;

public class TestWheelControl : MonoBehaviour
{

    public Vector3 Velocity;

    public bool[] MyInput;

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

        float _abs = 0;


        if (Input.GetKey(KeyCode.Q))
        {
            Vel[0].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vel[0].z -= VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vel[1].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vel[1].z -= VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vel[2].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vel[2].z -= VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Vel[3].z += VelocityMagnitude;
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vel[3].z -= VelocityMagnitude;
        }

	    for (int i = 0; i < 4; i++)
	    {
            //Vel[i] = new Vector3();
            //Vel[i] = new Vector3(0, 0, VelocityMagnitude);

            //if (MyInput[i])
            //{
            //    Vel[i] *= -1;
            //    _abs++;
            //}

	        _abs += Vel[i].z;

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

	    //TODO
        /*
        if(_abs < VelocityMagnitude * 3)
	        for (int i = 0; i < 4; i++)
	        {
	            if (Vel[i].z < 0)
	            {
	                    GetCollider(i).motorTorque *= 3;
                        Debug.Log("IT HAPPENED");
	            }
	        }
        else
        if (_abs > VelocityMagnitude * -3)
            for (int i = 0; i < 4; i++)
            {
                if (Vel[i].z > 0)
                {
                    GetCollider(i).motorTorque *= 3;
                    Debug.Log("IT HAPPENED");
                }
            }*/

	    float steerRate = 45.0f;


	    /*if (_abs == 3)
	    {
	        for (int i = 0; i < 4; i++)
	        {
	            if (!Input[i])
	            {
	                for (int y = 0; y < 4; y++)
	                {
                        GetCollider(y).steerAngle = (i < 2) ? -steerRate : steerRate;
	                }

                    GetCollider(i).steerAngle = 0;
	            }
	        }
	    }

        if (_abs == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Input[i])
                {
                    for (int y = 0; y < 4; y++)
                    {
                        GetCollider(y).steerAngle = (i < 2) ? steerRate : -steerRate;
                    }

                    GetCollider(i).steerAngle = 0;
                }
            }
        }*/
        
	}

    WheelCollider GetCollider(int n)
    {
        return this.transform.GetChild(4 + n).GetComponent<WheelCollider>();
    }
}
