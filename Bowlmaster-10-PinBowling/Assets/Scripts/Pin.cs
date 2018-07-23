using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(name + " " + IsStanding());
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuller = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotationInEuller.x);
        float tiltInZ = Mathf.Abs(rotationInEuller.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        return false;
    }

    void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
    }

}
