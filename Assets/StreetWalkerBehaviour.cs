using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class StreetWalkerBehaviour : MonoBehaviour
{

    private float _lastUpdate = 0;
    private Vector3 _destination;

    public float UpdateFrequency = 3;

    public CarController Player;

    public float ProximityForPickup = 2;
    public float MaximumVelocityForPickup = 200;

    public bool WantsToBePickedUp = false;

    public GameObject DestinationPrefab;

    public AnimationClip IdleAnimation;
    public AnimationClip RunAnimation;

	// Use this for initialization
	void Start () {
	
	}

    bool CheckProximity()
    {
        if (Vector3.Distance(Player.transform.localPosition, transform.localPosition) < ProximityForPickup)
            return true;
        return false;
    }
	
	// Update is called once per frame
	void Update () {

	    if (!WantsToBePickedUp)
        {
            this.animation.CrossFade("run");

	        //Debug.Log(Time.time - _lastUpdate);
	        if (Time.time - _lastUpdate > UpdateFrequency)
	        {
	            Vector3 randomDirection = Random.insideUnitSphere*15;

	            randomDirection += transform.position;

	            _destination = randomDirection;

	            _lastUpdate = Time.time;

	            Debug.Log("Updated human");
	        }

	        NavMeshHit hit;

	        NavMesh.SamplePosition(_destination, out hit, 100, 1);

	        Vector3 finalPosition = hit.position;

	        finalPosition.y = transform.position.y;

	        if (!float.IsNaN(finalPosition.x))
	        {
	            transform.LookAt(finalPosition);

	            //transform.rigidbody.AddForce((finalPosition - transform.position).normalized * Time.deltaTime, ForceMode.VelocityChange);

	            GetComponent<NavMeshAgent>().SetDestination(finalPosition);
	        }
	    }
	    else
        {
            this.animation.CrossFade("idle");
	        //Check for player movement
	        if (Player == null)
	            return;
            if (!Player.HasPickup && CheckProximity())
            {
                Debug.Log("Is in Proximity");
                if (Player.rigidbody.velocity.sqrMagnitude < MaximumVelocityForPickup)
                {
                    Debug.Log("Picked up");
                    //Pickup
                    Player.HasPickup = true;


                    //Create destination for dropoff
                    Vector3 randomDirection = Random.insideUnitSphere * 100;

                    randomDirection += transform.position;

                    _destination = randomDirection;

                    NavMeshHit hit;

                    NavMesh.SamplePosition(_destination, out hit, 1000, 1);

                    Vector3 finalPosition = hit.position;

                    finalPosition.y = transform.position.y;



                    Player.GetComponent<PointArrowAtTarget>().TargetObject = Instantiate(DestinationPrefab, finalPosition, transform.rotation) as GameObject;

                    //Delete this human
                    Destroy(this.gameObject);
                }
            }
	    }

	    //transform.position += (finalPosition - transform.position)*Time.deltaTime;
	}
}
