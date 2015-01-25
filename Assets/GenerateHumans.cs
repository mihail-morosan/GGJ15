using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateHumans : MonoBehaviour {
    public int number;
    public int WalkSpeed = 5;
    int current_no;
    public GameObject human;
    List<GameObject> humans;
	// Use this for initialization
	void Start () {
        Generate(number);
        current_no = number;
	
	}
	
	// Update is called once per frame
	void Update () {
	   /* foreach (GameObject go in humans){
            rigidbody.velocity = transform.forward * WalkSpeed;
        }*/
	}

    void Generate(int n)
    {
        for (int i = 0; i < number; i++)
        {
            float x = Random.Range(this.renderer.bounds.min.x + 2, this.renderer.bounds.max.x - 2);
            float z = Random.Range(this.renderer.bounds.min.z + 2, this.renderer.bounds.max.z - 2);
            float y = transform.position.y + 1;
            Vector3 posgen = new Vector3(x, y, z);
            GameObject go = Instantiate(human, posgen, Quaternion.identity) as GameObject;
            int factor = Random.Range(1, 3) == 1 ? -1 : 1;
            go.SendMessage("InitWalkSpeed", factor);
          //  humans.Add(go);
        }
    }

    
}
