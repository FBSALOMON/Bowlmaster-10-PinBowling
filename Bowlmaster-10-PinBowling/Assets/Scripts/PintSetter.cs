using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintSetter : MonoBehaviour {
   

    public GameObject pinSet;

    private PinCounter pinCounter;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	
	// Update is called once per frame
	void Update () {
        

	}

    public void RaisePins()
    {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position = new Vector3(0, 40, 1829);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.GetComponent<Rigidbody>().useGravity = false;
        }
    }
 
    public void PerfomeAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Game ends");
        }
    }
}
