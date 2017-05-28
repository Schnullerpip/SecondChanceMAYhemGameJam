using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDeactivator : AReceiver
{
    protected override void ReceiverBehaviour()
    {
        gameObject.GetComponent<LaserSender>().Activate(false);
    }
}
