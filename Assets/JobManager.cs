using UnityEngine;
using System.Collections;

public class JobManager : MonoBehaviour {
    public GameObject target;
    public CarController player;
    public DestinationBehaviour destination;
    public float proxiRange;
    public int stopValue;
    GameObject newTarget;

    public int PointsOnSuccess = 100;
    public int BonusSecondsOnSuccess = 20;

    public StreetWalkerBehaviour walker;
    public GameObject DestinationPrefab;
    public GameObject WalkerPrefab;
	// Use this for initialization
	void Start () {
        destination.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.HasPickup)
        {
            print("found pickup");
            if (!destination.gameObject.activeSelf){
                destination.gameObject.transform.position = walker.GetPickupDestination();
                destination.gameObject.SetActive(true);
                player.GetComponent<PointArrowAtTarget>().TargetObject = destination.gameObject;
                walker.gameObject.SetActive(false);
                print("made destination");
            }
            
            if (destination.Reached())
            {
                print("reached destination");
               // Vector3 nextPos = Random.insideUnitSphere * 15;
               // nextPos += destination.transform.position;
                if (!walker.gameObject.activeSelf)
                {
                    walker.transform.position = GetRandomVector(walker.gameObject);
                    walker.gameObject.SetActive(true);
                    player.GetComponent<PointArrowAtTarget>().TargetObject = walker.gameObject;
 
                }
                player.HasPickup = false;
                destination._reached = false;
                destination.gameObject.SetActive(false);

                player.GetComponent<ScoreManagement>().AddPoints(PointsOnSuccess);
                player.GetComponent<ScoreManagement>().AddSeconds(BonusSecondsOnSuccess);

            }
        }

	}

    bool checkProxi(CarController player, Vector3 target)
    {
        return Vector3.Distance(player.transform.localPosition, target) < proxiRange;
    }
    bool checkStop(GameObject player)
    {
        return player.rigidbody.velocity.sqrMagnitude < stopValue;
    }


    Vector3 GetRandomVector(GameObject target)
    {
        Vector3 _destination;
        Vector3 randomDirection = Random.insideUnitSphere * 115;

        randomDirection += target.transform.position;

        _destination = randomDirection;

        NavMeshHit hit;

        NavMesh.SamplePosition(_destination, out hit, 115, 1 << NavMesh.GetNavMeshLayerFromName("Street"));

        Vector3 finalPosition = hit.position;

        finalPosition.y = 0;

        return finalPosition;

    }
}
