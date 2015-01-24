using UnityEngine;
using System.Collections;

public class HumanBehaviour : MonoBehaviour {
    public float WalkSpeed;
	// Use this for initialization
	void Start () {
        //WalkSpeed = 100f;
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = transform.forward * WalkSpeed;
	}

    void turnLeft()
    {
        transform.Rotate(0, -90, 0);
    }

    void turnRight()
    {
        this.transform.Rotate(0, 90, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "left")
        {
            turnLeft();
        }
        if (col.gameObject.tag == "right")
        {
            turnRight();
        }
        if (col.gameObject.tag == "rightchance")
        {
              turnRight();
        }
        if (col.gameObject.tag == "leftchance")
        {
            int num = Random.Range(1, 5);
            if (num == 3)
                turnLeft();
        }
        if (col.gameObject.tag == "lr")
        {
            if (WalkSpeed < 0) turnRight();
            else turnLeft();
        }
        if (col.gameObject.tag == "lrchance")
        {
            int num = Random.Range(1, 5);
            if (num == 3){
                if (WalkSpeed < 0) turnRight();
            else turnLeft();
            }
        }
        if (col.gameObject.tag == "ai_car")
        {
            
            
            print("play death sound");
            Destroy(this);
        }
        if (col.gameObject.tag == "car")
        {
            print("scream stuff");
            print("stain car with blood!");
            Destroy(this);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(col.collider, collider);
        }
    }

    void InitWalkSpeed(int factor)
    {
        WalkSpeed *= factor;
    }
}
