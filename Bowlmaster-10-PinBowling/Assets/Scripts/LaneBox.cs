using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

    private PintSetter pintSetter;
	// Use this for initialization
	void Start () {
        pintSetter = GameObject.FindObjectOfType<PintSetter>();
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            pintSetter.SetBallOutOfPlay();
        }
    }
}
