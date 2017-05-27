using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{

    private Sender m_Sender;
    private bool alreadyLeft = false;

	// Use this for initialization
	void Start ()
	{
	    m_Sender = GetComponentInParent<Sender>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerExit(Collider other)
    {
        m_Sender.TriggerReceivers();
        Destroy(this);
    }
}
