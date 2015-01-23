using UnityEngine;
using System.Collections;

public class CameraFollowCar : MonoBehaviour
{

    public GameObject ObjectToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (ObjectToFollow == null)
	        return;
        Vector3 _pos = new Vector3();
	    _pos = ObjectToFollow.transform.position;
	    _pos.y = 50;
	    this.transform.position = _pos;
	}
}
