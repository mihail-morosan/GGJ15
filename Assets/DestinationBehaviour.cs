using UnityEngine;
using System.Collections;

public class DestinationBehaviour : MonoBehaviour {
    public CarController player;
    public float ProximityForPickup = 4;
    public float MaximumVelocityForPickup = 200;
    public bool _reached;
	// Use this for initialization
	void Start () {
        //player = GameObject.Find("BasicTrollCar").GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.HasPickup && CheckProximity())
        {
            Debug.Log("Is in Proximity");
            if (player.rigidbody.velocity.sqrMagnitude < MaximumVelocityForPickup)
            {
                _reached = true;
            }
        }
	}

    public bool Reached()
    {

        return _reached;
    }

    bool CheckProximity()
    {
        if (Vector3.Distance(player.transform.localPosition, transform.localPosition) < ProximityForPickup)
            return true;
        return false;
    }

    void setPlayer(CarController Player)
    {
        this.player = Player;
    }
}
