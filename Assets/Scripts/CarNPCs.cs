using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarNPCs : MonoBehaviour {

	public GameGraph waypoints { get; set; }
	public float moveSpeed = 10.0f;
	public float minDistance = 2.0f;
	//public int currentWPIndex { get; set; }
	public float rayDistance;
	public Vector3 lastWP;
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

		Vector3 dir = transform.forward; //Quaternion.LookRotation(dir) * transform.position;//Quaternion.AngleAxis(-20, Vector3.up) * transform.position; //- transform.position;

		Debug.DrawRay (transform.position+new Vector3(0,1f,0), Quaternion.AngleAxis(35, Vector3.up) * transform.forward * rayDistance *2f);
		Debug.DrawRay (transform.position+new Vector3(0,1f,0), transform.forward * rayDistance);

		Ray middleRay = new Ray(transform.position+new Vector3(0,1f,0), transform.forward * rayDistance);
		Ray rightRay = new Ray(transform.position+new Vector3(0,1f,0), Quaternion.AngleAxis(35, Vector3.up) * transform.forward * rayDistance *2f);
		
		RaycastHit hit;
		if (Physics.Raycast (middleRay, out hit, rayDistance) || Physics.Raycast (rightRay, out hit, rayDistance)) {
			if(hit.collider.tag == "car"){
				if(Vector3.Angle(hit.collider.transform.forward,transform.forward)<90){
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

		//Count how long a car is stopped after a crash, and remove it eventually
		if (moveSpeed == 0) {
			stopFrameCounter ++;
		}

		//If another game object in the movement direction is too close, stop. Otherwise, move on.
		MoveTowardWaypoint();
		stopFrameCounter = 0;
		
		if(Vector3.Distance(currentWP.coords, transform.position) < minDistance)
		{
			//Select next waypoint randomly
			int currentWPIndex = Random.Range(0,currentWP.adjacent.Count);

			lastWP = currentWP.coords;
			currentWP = currentWP.adjacent[currentWPIndex];
		}
	}

	private void MoveTowardWaypoint()
	{
		Vector3 direction = currentWP.coords - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;

		transform.position += moveVector;

        //transform.Translate(moveVector);

		if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 4 * Time.deltaTime);
		}
		/*
        NavMeshHit hit;
		NavMesh.SamplePosition(currentWP.coords, out hit, 1000, 1);
        Vector3 finalPosition = hit.position;
	    GetComponent<NavMeshAgent>().SetDestination(finalPosition);
	    */
	}

	public void MoveBackToLine(){

		print ("Move back to Line");
		Vector3 closestPointOnLine = DistanceToRay (transform.position, lastWP, currentWP.coords);
		Node intermediateWP = new Node (closestPointOnLine, -1);
		intermediateWP.addAdjacent (currentWP);
		currentWP = intermediateWP;

		Debug.DrawLine (transform.position, closestPointOnLine);

	}
	
	private Vector3 DistanceToRay(Vector3 x0, Vector3 origin, Vector3 goal){
		float k = ((goal.z-origin.z) * (x0.x-origin.x) - (goal.x-origin.x) * (x0.z-origin.z)) / (Mathf.Pow((goal.z - origin.z),2) + Mathf.Pow((goal.x-origin.x),2));
		float x4 = x0.x - k*(goal.z - origin.z);
		float y4 = x0.z - k*(goal.x - origin.x);
		Vector3 closestPoint = new Vector3 (x4, 0, y4);

		print ("Origin: " + origin);
		print ("Goal: " + goal);
		print ("Midpoint: " + closestPoint);

		return closestPoint;
	}
}
