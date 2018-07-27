using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {
    

    //Return a list of individual frame scores, NOT cumulative.
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        for (int i = 1; i < rolls.Count; i += 2)
        {
            if(frameList.Count == 10) // Prevents 11th frame score;
            {
                break;
            }
            try
            {
                if (rolls[i - 1] + rolls[i] < 10) // Pins Normal
                {
                    frameList.Add(rolls[i] + rolls[i - 1]);
                }
                if(rolls[i-1] == 10) // strike
                {
                    i--;
                    frameList.Add(10 + rolls[i + 1] + rolls[i+2]);
                } else if (rolls[i] + rolls[i - 1] == 10) // spare
                {
                        frameList.Add(10 + rolls[i+1]);
                }
            }
            catch { }

        }
        return frameList;
    }

    //Returns a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativesScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativesScores.Add(runningTotal);
        }

        return cumulativesScores;
        
    }
}
