﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintSetter : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        text.text = CountStanding().ToString();
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
