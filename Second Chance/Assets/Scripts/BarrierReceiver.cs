using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierReceiver : AReceiver
{

    private Animator m_Animator;
    private bool isOpen = true;
    [SerializeField]
    public bool one_timer = false;
    private bool has_striggered = false;

    protected override void ReceiverBehaviour()
    {
        if (m_Animator)
        {
            if (one_timer && !has_striggered || !one_timer)
            {
                m_Animator.SetBool("close", isOpen);
                isOpen = !isOpen;
                has_striggered = true;
            }
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
