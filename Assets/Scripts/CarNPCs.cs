using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarNPCs : MonoBehaviour {

	public GameGraph waypoints { get; set; }
	public float moveSpeed = 10.0f;
	public float minDistance = 2.0f;
	//public int currentWPIndex { get; set; }
	public float rayDistance;
	public Node currentWP;
	private int stopFrameCounter;
	public System.Guid id;
	public GameObject logic;

	// Use this for initialization
	void Awake(){
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//currentWP = waypoints [currentWPIndex];

		Vector3 dir = transform.forward; //Quaternion.LookRotation(dir) * transform.position;//Quaternion.AngleAxis(-20, Vector3.up) * transform.position; //- transform.position;

		Debug.DrawRay (transform.position, Quaternion.AngleAxis(35, Vector3.up) * transform.forward * rayDistance *1.5f);
		
		Ray middleRay = new Ray(transform.position, transform.forward * rayDistance);
		Ray rightRay = new Ray(transform.position, Quaternion.AngleAxis(35, Vector3.up) * transform.forward * rayDistance *1.5f);
		
		RaycastHit hit;
		if (Physics.Raycast (middleRay, out hit, rayDistance) || Physics.Raycast (rightRay, out hit, rayDistance)) {
			if(hit.collider.tag == "car"){
				if(Vector3.Angle(hit.collider.transform.forward,transform.forward)<105){
					if(stopFrameCounter>800){
						print("Destroyed jammed car!");
						//Remove car from jam if not moving for > 800 frames, then respawn
						logic.GetComponent<Logic> ().removeSpawnpoint(this.id);
						logic.GetComponent<Logic> ().spawnCar();
						Destroy(this.gameObject);
					}
					stopFrameCounter ++;
					return;
				}
			}
		}

		//If another game object in the movement direction is too close, stop. Otherwise, move on.
		MoveTowardWaypoint();
		stopFrameCounter = 0;
		
		if(Vector3.Distance(currentWP.coords, transform.position) < minDistance)
		{
			//Select next waypoint randomly
			int currentWPIndex = Random.Range(0,currentWP.adjacent.Count);
			currentWP = currentWP.adjacent[currentWPIndex];
			/*
			++currentWPIndex;
			if(currentWPIndex > waypoints.Count -1)
			{
				currentWPIndex = 0;
			}
			*/
		}
	}

	private void MoveTowardWaypoint()
	{
		Vector3 direction = currentWP.coords - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position += moveVector;
		if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 4 * Time.deltaTime);
		}
	}
}
