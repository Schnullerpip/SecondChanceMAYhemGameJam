using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReceiver : AReceiver
{

    //MEMBER
    //the doors transform, so it can be moved by t´his receiver component
    private Transform m_Transform;
    //the doors Animator
    private Animator m_Animator;

    //the speed the door will open with
    public float speed = 10;

    //METHODS
    public override void ActOnReceive()
    {
        m_Animator.SetBool("shouldOpen", true);
    }


    //INHERITED METHODS
	// Use this for initialization
	void Start () {
		//get the gameobjects transform
	    m_Transform = gameObject.GetComponent<Transform>();
	    m_Animator = gameObject.GetComponent<Animator>();
	}

}
