using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logic : MonoBehaviour {

	public GameObject car;
	public int carCount = 4;
	public int nodeCount;
	private GameGraph graph;
	private List<List<Vector3>> paths;
	private GameObject carsContainer;
	private Dictionary<System.Guid, Vector3> spawnPoints;

	// Use this for initialization
	void Start () {
		
		//Load nodes
		graph = new GameGraph ();
		for (int i=0; i<nodeCount; i++) {
			string id = "n"+i;
			GameObject waypoint = GameObject.Find(id);
			Node n = new Node(waypoint.transform.position,i);
			graph.addNode(n);
		}

		graph.Nodes () [1].addAdjacent (graph.Nodes () [19]);
		graph.Nodes () [2].addAdjacent (graph.Nodes () [48]);
		graph.Nodes () [3].addAdjacent (graph.Nodes () [46]);
		graph.Nodes () [4].addAdjacent (graph.Nodes () [63]);
		graph.Nodes () [5].addAdjacent (graph.Nodes () [9]);
		graph.Nodes () [6].addAdjacent (graph.Nodes () [14]);
		graph.Nodes () [7].addAdjacent (graph.Nodes () [15]);
		graph.Nodes () [8].addAdjacent (graph.Nodes () [16]);
		graph.Nodes () [9].addAdjacent (graph.Nodes () [10]);
		graph.Nodes () [9].addAdjacent (graph.Nodes () [57]);
		graph.Nodes () [10].addAdjacent (graph.Nodes () [67]);
		graph.Nodes () [10].addAdjacent (graph.Nodes () [39]);
		graph.Nodes () [10].addAdjacent (graph.Nodes () [11]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [28]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [27]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [12]);
		graph.Nodes () [12].addAdjacent (graph.Nodes () [13]);
		graph.Nodes () [12].addAdjacent (graph.Nodes () [60]);
		graph.Nodes () [12].addAdjacent (graph.Nodes () [13]);
		graph.Nodes () [13].addAdjacent (graph.Nodes () [6]);
		graph.Nodes () [13].addAdjacent (graph.Nodes () [65]);
		graph.Nodes () [14].addAdjacent (graph.Nodes () [30]);
		graph.Nodes () [14].addAdjacent (graph.Nodes () [7]);
		graph.Nodes () [15].addAdjacent (graph.Nodes () [25]);
		graph.Nodes () [15].addAdjacent (graph.Nodes () [8]);
		graph.Nodes () [16].addAdjacent (graph.Nodes () [70]);
		graph.Nodes () [16].addAdjacent (graph.Nodes () [51]);
		graph.Nodes () [17].addAdjacent (graph.Nodes () [18]);
		graph.Nodes () [17].addAdjacent (graph.Nodes () [23]);
		graph.Nodes () [17].addAdjacent (graph.Nodes () [21]);
		graph.Nodes () [18].addAdjacent (graph.Nodes () [5]);
		graph.Nodes () [19].addAdjacent (graph.Nodes () [52]);
		graph.Nodes () [19].addAdjacent (graph.Nodes () [23]);
		graph.Nodes () [19].addAdjacent (graph.Nodes () [21]);
		graph.Nodes () [20].addAdjacent (graph.Nodes () [53]);
		graph.Nodes () [21].addAdjacent (graph.Nodes () [54]);
		graph.Nodes () [21].addAdjacent (graph.Nodes () [27]);
		graph.Nodes () [22].addAdjacent (graph.Nodes () [18]);
		graph.Nodes () [22].addAdjacent (graph.Nodes () [20]);
		graph.Nodes () [22].addAdjacent (graph.Nodes () [54]);
		graph.Nodes () [23].addAdjacent (graph.Nodes () [69]);
		graph.Nodes () [23].addAdjacent (graph.Nodes () [27]);
		graph.Nodes () [24].addAdjacent (graph.Nodes () [18]);
		graph.Nodes () [24].addAdjacent (graph.Nodes () [20]);
		graph.Nodes () [25].addAdjacent (graph.Nodes () [39]);
		graph.Nodes () [25].addAdjacent (graph.Nodes () [29]);
		graph.Nodes () [26].addAdjacent (graph.Nodes () [39]);
		graph.Nodes () [26].addAdjacent (graph.Nodes () [22]);
		graph.Nodes () [27].addAdjacent (graph.Nodes () [49]);
		graph.Nodes () [27].addAdjacent (graph.Nodes () [29]);
		graph.Nodes () [28].addAdjacent (graph.Nodes () [22]);
		graph.Nodes () [28].addAdjacent (graph.Nodes () [49]);
		graph.Nodes () [29].addAdjacent (graph.Nodes () [45]);
		graph.Nodes () [29].addAdjacent (graph.Nodes () [58]);
		graph.Nodes () [30].addAdjacent (graph.Nodes () [58]);
		graph.Nodes () [30].addAdjacent (graph.Nodes () [26]);
		graph.Nodes () [31].addAdjacent (graph.Nodes () [45]);
		graph.Nodes () [32].addAdjacent (graph.Nodes () [26]);
		graph.Nodes () [32].addAdjacent (graph.Nodes () [28]);
		graph.Nodes () [33].addAdjacent (graph.Nodes () [10]);
		graph.Nodes () [34].addAdjacent (graph.Nodes () [1]);
		graph.Nodes () [34].addAdjacent (graph.Nodes () [56]);
		graph.Nodes () [35].addAdjacent (graph.Nodes () [1]);
		graph.Nodes () [36].addAdjacent (graph.Nodes () [11]);
		graph.Nodes () [37].addAdjacent (graph.Nodes () [34]);
		graph.Nodes () [37].addAdjacent (graph.Nodes () [67]);
		graph.Nodes () [37].addAdjacent (graph.Nodes () [35]);
		graph.Nodes () [38].addAdjacent (graph.Nodes () [34]);
		graph.Nodes () [38].addAdjacent (graph.Nodes () [35]);
		graph.Nodes () [39].addAdjacent (graph.Nodes () [12]);
		graph.Nodes () [40].addAdjacent (graph.Nodes () [38]);
		graph.Nodes () [40].addAdjacent (graph.Nodes () [37]);
		graph.Nodes () [40].addAdjacent (graph.Nodes () [28]);
		graph.Nodes () [41].addAdjacent (graph.Nodes () [38]);
		graph.Nodes () [41].addAdjacent (graph.Nodes () [37]);
		graph.Nodes () [42].addAdjacent (graph.Nodes () [13]);
		graph.Nodes () [42].addAdjacent (graph.Nodes () [62]);
		graph.Nodes () [43].addAdjacent (graph.Nodes () [60]);
		graph.Nodes () [43].addAdjacent (graph.Nodes () [41]);
		graph.Nodes () [43].addAdjacent (graph.Nodes () [40]);
		graph.Nodes () [44].addAdjacent (graph.Nodes () [41]);
		graph.Nodes () [44].addAdjacent (graph.Nodes () [40]);
		graph.Nodes () [45].addAdjacent (graph.Nodes () [7]);
		graph.Nodes () [46].addAdjacent (graph.Nodes () [4]);
		graph.Nodes () [47].addAdjacent (graph.Nodes () [4]);
		graph.Nodes () [48].addAdjacent (graph.Nodes () [3]);
		graph.Nodes () [48].addAdjacent (graph.Nodes () [25]);
		graph.Nodes () [48].addAdjacent (graph.Nodes () [26]);
		graph.Nodes () [49].addAdjacent (graph.Nodes () [8]);
		graph.Nodes () [50].addAdjacent (graph.Nodes () [3]);
		graph.Nodes () [47].addAdjacent (graph.Nodes () [4]);
		graph.Nodes () [51].addAdjacent (graph.Nodes () [17]);
		graph.Nodes () [51].addAdjacent (graph.Nodes () [18]);
		graph.Nodes () [52].addAdjacent (graph.Nodes () [2]);
		graph.Nodes () [52].addAdjacent (graph.Nodes () [70]);
		graph.Nodes () [53].addAdjacent (graph.Nodes () [2]);
		graph.Nodes () [54].addAdjacent (graph.Nodes () [68]);
		graph.Nodes () [54].addAdjacent (graph.Nodes () [55]);
		graph.Nodes () [55].addAdjacent (graph.Nodes () [33]);
		graph.Nodes () [55].addAdjacent (graph.Nodes () [35]);
		graph.Nodes () [56].addAdjacent (graph.Nodes () [24]);
		graph.Nodes () [56].addAdjacent (graph.Nodes () [23]);
		graph.Nodes () [57].addAdjacent (graph.Nodes () [24]);
		graph.Nodes () [57].addAdjacent (graph.Nodes () [23]);
		graph.Nodes () [58].addAdjacent (graph.Nodes () [66]);
		graph.Nodes () [58].addAdjacent (graph.Nodes () [59]);
		graph.Nodes () [59].addAdjacent (graph.Nodes () [42]);
		graph.Nodes () [59].addAdjacent (graph.Nodes () [44]);
		graph.Nodes () [60].addAdjacent (graph.Nodes () [32]);
		graph.Nodes () [60].addAdjacent (graph.Nodes () [31]);
		graph.Nodes () [60].addAdjacent (graph.Nodes () [66]);
		graph.Nodes () [61].addAdjacent (graph.Nodes () [32]);
		graph.Nodes () [61].addAdjacent (graph.Nodes () [31]);
		graph.Nodes () [62].addAdjacent (graph.Nodes () [6]);
		graph.Nodes () [63].addAdjacent (graph.Nodes () [44]);
		graph.Nodes () [63].addAdjacent (graph.Nodes () [43]);
		graph.Nodes () [63].addAdjacent (graph.Nodes () [44]);
		graph.Nodes () [64].addAdjacent (graph.Nodes () [43]);
		graph.Nodes () [64].addAdjacent (graph.Nodes () [44]);
		graph.Nodes () [65].addAdjacent (graph.Nodes () [59]);
		graph.Nodes () [66].addAdjacent (graph.Nodes () [62]);
		graph.Nodes () [67].addAdjacent (graph.Nodes () [55]);
		graph.Nodes () [68].addAdjacent (graph.Nodes () [36]);
		graph.Nodes () [69].addAdjacent (graph.Nodes () [51]);
		graph.Nodes () [70].addAdjacent (graph.Nodes () [21]);


		/*
		graph.Nodes () [0].addAdjacent (graph.Nodes () [10]);
		graph.Nodes () [10].addAdjacent (graph.Nodes () [1]);
		graph.Nodes () [1].addAdjacent (graph.Nodes () [2]);
		graph.Nodes () [2].addAdjacent (graph.Nodes () [13]);
		graph.Nodes () [13].addAdjacent (graph.Nodes () [3]);
		graph.Nodes () [3].addAdjacent (graph.Nodes () [0]);

		graph.Nodes () [4].addAdjacent (graph.Nodes () [7]);
		graph.Nodes () [7].addAdjacent (graph.Nodes () [8]);
		graph.Nodes () [8].addAdjacent (graph.Nodes () [12]);
		graph.Nodes () [12].addAdjacent (graph.Nodes () [6]);
		graph.Nodes () [6].addAdjacent (graph.Nodes () [5]);
		graph.Nodes () [5].addAdjacent (graph.Nodes () [11]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [9]);
		graph.Nodes () [9].addAdjacent (graph.Nodes () [4]);

		graph.Nodes () [8].addAdjacent (graph.Nodes () [9]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [12]);
		graph.Nodes () [8].addAdjacent (graph.Nodes () [10]);
		graph.Nodes () [11].addAdjacent (graph.Nodes () [13]);
		*/

		//Spawn cars on paths
		carsContainer = new GameObject("Cars");
		spawnPoints = new Dictionary<System.Guid, Vector3> ();
		for (int i=0; i<carCount; i++) {
			spawnCar();
		}
	}

	public bool spawnCar(){
		print("Spawning new car!");

		//int pathIndex = Random.Range(0,paths.Count);
		//List<Vector3> path = paths[pathIndex];
		
		int lastWaypointIndex = Random.Range(1,graph.Nodes().Count);
		Node lastWaypoint = graph.Nodes () [lastWaypointIndex];

		if (graph.Nodes () [lastWaypointIndex].adjacent.Count == 0) {
						print (graph.Nodes () [lastWaypointIndex].id);
				}
		Node currentWaypoint = graph.Nodes () [lastWaypointIndex].adjacent [0];
		//int currentWaypointIndex = graph.Nodes ().IndexOf (graph.Nodes () [lastWaypointIndex].adjacent [0]);
		
		//Linear Interpolation to get random starting position
		Vector3 startingPosition = Vector3.Lerp(lastWaypoint.coords, currentWaypoint.coords, Random.value);

		bool overlap = false;
		foreach (KeyValuePair<System.Guid, Vector3> entry in spawnPoints) {
			if(Vector3.Distance(startingPosition, entry.Value) < 1){
				overlap = true;
			}	
		}

		if(overlap){
			return false;
		} 
		System.Guid carGuid = System.Guid.NewGuid ();
		spawnPoints.Add(carGuid,startingPosition);
		
		//Create new car
		GameObject newCar = (GameObject)Instantiate(car, startingPosition, Quaternion.identity);
		newCar.GetComponent<CarNPCs> ().waypoints = graph;
		newCar.GetComponent<CarNPCs> ().currentWP = currentWaypoint;
		newCar.GetComponent<CarNPCs> ().logic = this.gameObject;
		newCar.GetComponent<CarNPCs> ().id = carGuid;
		newCar.transform.parent = carsContainer.transform;

		return true;
	}

	public void removeSpawnpoint(System.Guid id){
		if (!spawnPoints.ContainsKey (id)) {
			spawnPoints.Remove(id);		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
