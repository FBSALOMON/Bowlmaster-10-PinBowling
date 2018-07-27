using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private List<int> rolls = new List<int>();
    private PintSetter pintSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        pintSetter = GameObject.FindObjectOfType<PintSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

    public void Bowl (int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            ball.Reset();

            pintSetter.PerfomeAction(ActionMaster.NextAction(rolls));

           
        } catch
        {
            Debug.LogWarning("Something went wrong in Bowl()");
        }

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        } catch
        {
            Debug.LogWarning("FillRollCard failed");
        }
        
        
    }
}
