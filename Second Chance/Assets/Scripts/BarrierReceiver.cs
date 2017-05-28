﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierReceiver : AReceiver
{

    private Animator m_Animator;
    private bool isOpen = true;

    protected override void ReceiverBehaviour()
    {
        if (m_Animator)
        {
            m_Animator.SetBool("close", isOpen);
            isOpen = !isOpen;
        }
    }

	// Use this for initialization
	void Start ()
	{
	    m_Animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
