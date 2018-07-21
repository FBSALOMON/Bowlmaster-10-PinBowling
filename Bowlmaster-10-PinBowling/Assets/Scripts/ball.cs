using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchSpeed;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    public bool inPlay = false;
    // Use this for initialization

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
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
}
