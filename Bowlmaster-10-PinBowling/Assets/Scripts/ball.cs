using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchSpeed;
    private new Rigidbody rigidbody;
    private AudioSource audioSource;
    public bool inPlay = false;
    private Vector3 initialPosition;
    // Use this for initialization

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        initialPosition = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }


    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        inPlay = false;
        transform.position = initialPosition;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.rotation = Quaternion.identity;
        rigidbody.useGravity = false;
    }
}
