using UnityEngine;
using System.Collections;

public class GenerateHumans : MonoBehaviour {
    public int number;
    int current_no;
    public GameObject human;
	// Use this for initialization
	void Start () {
        Generate(number);
        current_no = number;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Generate(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posgen = transform.localPosition;
            print(posgen.x + " " + posgen.z);
            posgen.x += 2;
            posgen.y += 4;
            GameObject go = Instantiate(human, posgen, Quaternion.identity) as GameObject;
            int factor = Random.Range(1, 3) == 1 ? -1 : 1;
            go.SendMessage("InitWalkSpeed", factor);
        }
    }

    
}
