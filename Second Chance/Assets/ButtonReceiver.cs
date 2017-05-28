using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReceiver : AReceiver {

    protected override void ReceiverBehaviour()
    {
        GetComponent<Sender>().TriggerReceivers();
    }
}
