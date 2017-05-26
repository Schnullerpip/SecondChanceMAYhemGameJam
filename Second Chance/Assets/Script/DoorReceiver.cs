using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReceiver : AReceiver
{

    //MEMBER
    //the doors transform, so it can be moved by t´his receiver component
    private Transform m_Transform;

    //the speed the door will open with
    public float speed = 10;

    //METHODS
    public override void ActOnReceive()
    {
        m_Transform.Translate(m_Transform.forward * speed * Time.deltaTime);
    }


    //INHERITED METHODS
	// Use this for initialization
	void Start () {
		//get the gameobjects transform
	    m_Transform = gameObject.GetComponent<Transform>();
	}

}
