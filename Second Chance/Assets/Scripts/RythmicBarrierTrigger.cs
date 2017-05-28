﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmicBarrierTrigger : MonoBehaviour
{

    [SerializeField]
    private float wait_time_in_seconds;

    public BarrierReceiver m_Barrier;



	// Use this for initialization
	void Start ()
	{
	    m_Barrier = GetComponent<BarrierReceiver>();
	    StartCoroutine(TriggerBarrier());
	}

    IEnumerator TriggerBarrier()
    {
        while (true)
        {
            m_Barrier.ActOnReceive();
            yield return new WaitForSeconds(wait_time_in_seconds);
        }
    }
	
}
