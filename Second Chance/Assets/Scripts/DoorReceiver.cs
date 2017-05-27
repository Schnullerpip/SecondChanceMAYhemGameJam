using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReceiver : AReceiver
{

    //MEMBER
    //the doors Animator
    private Animator m_Animator;

    //METHODS
    public override void ActOnReceive()
    {
        m_Animator.SetBool("shouldOpen", true);
    }


    //INHERITED METHODS
	// Use this for initialization
	void Start () {
		//get the gameobjects transform
	    m_Animator = gameObject.GetComponent<Animator>();
	}

}
