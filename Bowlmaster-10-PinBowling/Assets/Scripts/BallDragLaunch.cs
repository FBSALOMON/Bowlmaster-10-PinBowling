using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart,dragEnd;
    private float startTime, endTime;
    private float maxDistance;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
	}

    // Capture time & position of drag start
    public void DragStart ()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    // Launch the ball
    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;
        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragEnd.x - dragStart.x) / (dragDuration);
        float launchSpeedZ = (dragEnd.y - dragStart.y) / (dragDuration);

        ball.Launch(new Vector3(launchSpeedX, 0 , launchSpeedZ));
    }

    public void MoveStart (float amount)
    {
        if (!ball.inPlay)
        {
            float zPosition = ball.transform.position.z;
            float yPosition = ball.transform.position.y;
            transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f), yPosition, zPosition);
        }
        
    }
}
