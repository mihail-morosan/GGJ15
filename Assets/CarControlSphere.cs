using UnityEngine;
using System.Collections;

public class CarControlSphere : MonoBehaviour {

    public float VelocityMagnitude;

	// Use this for initialization
	void Start () {

        rigidbody.centerOfMass = new Vector3(0, -0.5f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
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

            GetWheel(i).AddTorque(Vel[i]);
        }
	}

    Rigidbody GetWheel(int n)
    {
        return this.transform.GetChild(n).GetComponent<Rigidbody>();
    }
}
