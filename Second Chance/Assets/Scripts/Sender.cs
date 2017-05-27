﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{

    //MEMBER
    //reference to the receiver in the game
    public AReceiver[] AReceivers;


    //METHODS
    public void TriggerReceivers()
    {
        foreach (AReceiver t in AReceivers)
        {
            t.ActOnReceive();
        }
    }
}
