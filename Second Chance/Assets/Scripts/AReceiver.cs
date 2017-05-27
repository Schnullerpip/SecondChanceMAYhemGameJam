using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AReceiver : MonoBehaviour
{
    //the generic method that is trigered by a receiver, that knows this receiver
    public abstract void ActOnReceive();
}
