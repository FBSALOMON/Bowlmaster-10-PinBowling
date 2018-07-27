using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float distanceToRaise = 40f;
    public float standingThreshold = 3f;
    private new Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuller = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotationInEuller.x);
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

    public void Raise()
    {
        if (IsStanding())
        {
            transform.rotation = Quaternion.Euler(270f, 0, 0);
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            rigidbody.useGravity = false;
        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
                rigidbody.useGravity = true;
        }
    }
}
