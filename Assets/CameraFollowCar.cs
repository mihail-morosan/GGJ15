using UnityEngine;
using System.Collections;

public class CameraFollowCar : MonoBehaviour
{

    public GameObject ObjectToFollow;

    public float VerticalHeight = 20.0f;

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
	    _pos.y = VerticalHeight;
	    this.transform.position = _pos;
	}
}
