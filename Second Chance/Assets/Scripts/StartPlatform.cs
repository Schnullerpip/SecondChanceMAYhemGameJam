using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{

    private Sender m_Sender;
    private AudioSource m_Audio;

	// Use this for initialization
	void Start ()
	{
	    m_Sender = GetComponentInParent<Sender>();
	    m_Audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerExit(Collider other)
    {

        m_Audio.Play();

        //whoever wants to be triggered by this go ahead
        m_Sender.TriggerReceivers();

        //per definition we want the TimeShifter to slow down, as soon as the player leaves the platform
        TimeShifter.Instance.SlowDown();

        //make sure this trigger wont trigger ever again
        Destroy(this);
    }
}
