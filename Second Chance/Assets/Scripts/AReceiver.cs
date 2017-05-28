using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AReceiver : MonoBehaviour
{
    private int receiveCounter = 0;
    public int ReceivedNTimes()
    {
        return receiveCounter;
    }

    public void ActOnReceive()
    {
        ++receiveCounter;
        ReceiverBehaviour();
    }

    //the generic method that is trigered by a receiver, that knows this receiver
    protected abstract void ReceiverBehaviour();
}
