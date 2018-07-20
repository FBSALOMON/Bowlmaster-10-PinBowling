using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public float launchSpeed;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Launch();
    }

    public void Launch()
    {
        rigidbody.velocity = new Vector3(0, 0, launchSpeed);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
