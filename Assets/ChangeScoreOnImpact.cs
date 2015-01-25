using System.Timers;
using UnityEngine;
using System.Collections;

public class ChangeScoreOnImpact : MonoBehaviour
{

    public int ScoreChange = 50;

    public bool DestroyOnCollision = true;

    public int SecondsToAdd = 0;

    public GameObject SpawnOnDeath;

    private float _oldMoveSpeed;
    private float _whenSetSpeed = 0;

    public AudioClip Crash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.GetComponent<CarNPCs>() != null && transform.GetComponent<CarNPCs>().moveSpeed == 0 && Time.time - _whenSetSpeed > 2)
        {
            ResetMovement();
        }
	}

    void ResetMovement()
    {
        if (transform.GetComponent<CarNPCs>() != null)
            transform.GetComponent<CarNPCs>().moveSpeed = _oldMoveSpeed;
    }

	void OnCollisionExit(Collision Coll){
		if (Coll.transform.tag == "Player" && transform.tag == "car") {
			transform.GetComponent<CarNPCs> ().MoveBackToLine ();
		}
	}

    void OnCollisionEnter(Collision Coll)
    {
		/*
		if (Coll.transform.tag == "car") {
			print ("crashed!");
		}*/
        if (Coll.transform.tag == "Player")
        {
            if (Coll.transform.GetComponent<ScoreManagement>() != null)
            {
                Coll.transform.GetComponent<ScoreManagement>().AddPoints(ScoreChange);
                Coll.transform.GetComponent<ScoreManagement>().AddSeconds(SecondsToAdd);
            }

            //Change this to temporal
            if (transform.GetComponent<CarNPCs>() != null)
            {
                if (Crash != null)
                {
                    Debug.Log("SoundCrash");
                    audio.PlayOneShot(Crash);
                }

                _oldMoveSpeed = transform.GetComponent<CarNPCs>().moveSpeed;
                transform.GetComponent<CarNPCs>().moveSpeed = 0;

                _whenSetSpeed = Time.time;
            }


            if (SpawnOnDeath != null)
            {
                Instantiate(SpawnOnDeath, transform.position - new Vector3(0, 3, 0), transform.rotation);
            }

            if (DestroyOnCollision)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
