using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintSetter : MonoBehaviour {
   
    public Text text;
    public GameObject pinSet;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1; 
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;
    private Ball ball;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(ballOutOfPlay)
        {
            text.text = CountStanding().ToString();
            text.color = Color.red;
            UpdateStandingCountAndSettle();
        }
	}

    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }

    public void RaisePins()
    {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
            pin.transform.rotation = Quaternion.Euler(270f, 0, 0);
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
 
    void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; 

        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn)
        {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Game ends");
        }
        ball.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
        text.color = Color.green;
    }

    private int CountStanding()
    {
        int standing = 0;
       foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
}
