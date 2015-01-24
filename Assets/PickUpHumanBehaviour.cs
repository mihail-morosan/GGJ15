using UnityEngine;
using System.Collections;

public class PickUpHumanBehaviour : MonoBehaviour {
    public GameObject player;
    bool inProximity;
    public float proxiRange;
    public float stopValue;
	// Use this for initialization
	void Start () {
        inProximity = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (player == null)
	        return;
        if (checkProxi())
        {
            if (player.rigidbody.velocity.sqrMagnitude < stopValue){
            }
        }
	}

    bool checkProxi()
    {
        if (Vector3.Distance(player.transform.localPosition, transform.localPosition) < proxiRange)
            return true;
        return false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // add code for player score adjustment
            this.gameObject.SetActive(false); 
        }
    }
}
