using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int bowl = 1;
    private int[] bowls = new int[21];

    public static Action NextAction (List<int> pinFalls)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action currentAction = new Action();

        foreach (int roll in pinFalls)
        {
            currentAction = actionMaster.Bowl(roll);
        }
        return currentAction;
    }

    public Action Bowl (int pins) // TODO make private
    {
        if (pins < 0 || pins > 10) {throw new UnityException("Invalid pins");}

        bowls[bowl - 1] = pins;

        if(bowl == 21)
        {
            return Action.EndGame;
        }
        //HandleLastFramesCases
       if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20)
        {
            bowl++;
            if (bowls[18] == 10 && bowls[19] ==0 )
            {
                return Action.Tidy;
            }
            if ((bowls[18] + bowls[19]) % 10 == 0)
            {
                return Action.Reset;
            } else if (Bowl21Awarded())
            {
                return Action.Tidy;
            } else
            {
                return Action.EndGame;
            }
        }

        if (pins == 10 && bowl%2!=0)
        {
            bowl += 2;
            return Action.EndTurn;
        }

        //If first bowl of frame
        // return Action.Tidy;
        if (bowl % 2 != 0)  // Mid frame (or last frame)
        {
            bowl += 1;
            return Action.Tidy;
        } else if (bowl % 2 == 0) // Enf of frame
        {
            bowl += 1;
            return Action.EndTurn;
        }
        throw new UnityException("Not sure what action to return !");
    }

    private bool Bowl21Awarded()
    {
        return (bowls[18] + bowls[19] >= 10);
    }
}