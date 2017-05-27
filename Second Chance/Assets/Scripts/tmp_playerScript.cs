using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_playerScript : MonoBehaviour
{

    private Sender m_Sender;

	// Use this for initialization
	void Start ()
	{
	    m_Sender = gameObject.GetComponent<Sender>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (m_Sender == null)
	        {
                Debug.Log("m_Sender was not found!");
	            return;
	        }
            m_Sender.TriggerReceivers();
	    }
	}
}
