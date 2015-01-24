using UnityEngine;
using System.Collections;

public class PointArrowAtTarget : MonoBehaviour
{

    public GameObject TargetObject;
    public GameObject Arrow;

    public float RotateSpeed = 5.0f;

	// Use this for initialization
	void Start () {

	}
    
    void Update()
    {
        if (Arrow == null || TargetObject == null)
            return;

        //Arrow.transform.LookAt(TargetObject.transform);

        Vector3 targetDir = TargetObject.transform.position - transform.position;
        targetDir.y = 0;
        float step = RotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(Arrow.transform.forward, targetDir, step, 0.0F);
        //Debug.DrawRay(transform.position, TargetObject.transform.position, Color.red);

        //newDir.x = 0;
        //newDir.z = 0;
        
        Arrow.transform.rotation = Quaternion.LookRotation(newDir);


        Arrow.transform.position = transform.position;
    }
}
