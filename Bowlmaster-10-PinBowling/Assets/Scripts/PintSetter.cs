using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintSetter : MonoBehaviour {
    public int lastStandingCount = -1;
    public Text text;
    public GameObject pinSetter;

    private float lastChangeTime;
    private bool BallEntredBox = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(BallEntredBox)
        {
            text.text = CountStanding().ToString();
            UpdateStandingCountAndSettle();
        }
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
        GameObject newPins = Instantiate(pinSetter);
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
        ball.Reset();
        lastStandingCount = -1;
        BallEntredBox = false;
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

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;

        if (thingHit.GetComponent<Ball>())
        {
            BallEntredBox = true;
            text.color = Color.red;
        }
    }
}
