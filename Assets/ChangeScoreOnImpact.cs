using UnityEngine;
using System.Collections;

public class ChangeScoreOnImpact : MonoBehaviour
{

    public int ScoreChange = 50;

    public bool DestroyOnCollision = true;

    public int SecondsToAdd = 0;

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
            Coll.transform.GetComponent<ScoreManagement>().AddPoints(ScoreChange);
            Coll.transform.GetComponent<ScoreManagement>().AddSeconds(SecondsToAdd);

            if (DestroyOnCollision)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
