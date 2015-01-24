using UnityEngine;
using System.Collections;

public class JobManager : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    public float proxiRange;
    public int stopValue;
    GameObject newTarget;
    Vector3[] waypoints;
    int jobStatus;
	// Use this for initialization
	void Start () {
        jobStatus = 0;
        newTarget = Instantiate(target, waypoints[Random.Range(0, waypoints.Length)], Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void PickUp(GameObject target)
    {
        if (checkProxi(player,target))
            if (checkStop(player))
            {
               // jobStatus: 0 = looking for customer
                //           1 = going to destination
                //           2 = delivered
                if (jobStatus == 1)
                {   jobStatus = 2;
                    return;
                }
                if (jobStatus == 0)
                {
                    jobStatus = 1;
                    return;
                }
                if (jobStatus == 2)
                {
                    jobStatus = 0;
                    return;
                }
                // add player score too in if statements.
                newTarget = Instantiate(target, waypoints[Random.Range(0, waypoints.Length)], Quaternion.identity) as GameObject;
                
            }
        
    }

    bool checkProxi(GameObject player, GameObject target)
    {
        return Vector3.Distance(player.transform.localPosition, target.transform.localPosition) < proxiRange;
    }
    bool checkStop(GameObject player)
    {
        return player.rigidbody.velocity.sqrMagnitude < stopValue;
    }
    void InitializeWaypoints()
    {
        waypoints[0] = new Vector3(2.19f, 3f, -4.2f);
        waypoints[1] = new Vector3(-1f, 3f, -4.3f);
        waypoints[2] = new Vector3(0.6f, 3f, 4.2f);
        waypoints[3] = new Vector3(-1.2f, 3f, 5f);
    }
    void OnCollisionEntry(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // score -
            newTarget = Instantiate(target, waypoints[Random.Range(0, waypoints.Length)], Quaternion.identity) as GameObject;
            jobStatus = 0;
        }
    }
}
