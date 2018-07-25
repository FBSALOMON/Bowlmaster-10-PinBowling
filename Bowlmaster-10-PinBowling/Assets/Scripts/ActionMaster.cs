using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster : MonoBehaviour {

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    public Action Bowl (int pins)
    {
        return Action.EndGame;
    }
}
