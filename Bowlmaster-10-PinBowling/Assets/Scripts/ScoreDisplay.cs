using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollsTexts, frameTexts;

    public void FillRolls (List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        for(int i = 0; i < scoreString.Length; i++)
        {
            rollsTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames (List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls (List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;
            if(rolls[i] == 0) // Zero
            {
                output += "-";
            } else if ((box % 2 == 0 || box == 21) && rolls[i] + rolls[i - 1] == 10) // Spare
            {
                output += "/";
            } else if (box >= 19 && rolls[i] == 10) // Strike in Frame 10
            {
                output += "X";
            } else if(rolls[i] == 10) //Strike in Frame 1-9
            {
                output += "X ";
            } else
            {
                output += rolls[i].ToString();  // Normal 1-9
            }
            
        }
        return output;
    }
}
