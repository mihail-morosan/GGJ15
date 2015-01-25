using UnityEngine;
using System.Collections;

public class ChangeScoreOnImpact : MonoBehaviour
{

    public int ScoreChange = 50;

    public bool DestroyOnCollision = true;

    public int SecondsToAdd = 0;

    public GameObject SpawnOnDeath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision Coll)
    {
        if (Coll.transform.tag == "Player")
        {
            if (Coll.transform.GetComponent<ScoreManagement>() != null)
            {
                Coll.transform.GetComponent<ScoreManagement>().AddPoints(ScoreChange);
                Coll.transform.GetComponent<ScoreManagement>().AddSeconds(SecondsToAdd);
            }

            //Change this to temporal
            if(transform.GetComponent<CarNPCs>()!=null)
                transform.GetComponent<CarNPCs>().moveSpeed = 0;

            if (SpawnOnDeath != null)
            {
                Instantiate(SpawnOnDeath, transform.position, transform.rotation);
            }

            if (DestroyOnCollision)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
