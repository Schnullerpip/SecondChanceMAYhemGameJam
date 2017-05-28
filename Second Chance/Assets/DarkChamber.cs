using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkChamber : MonoBehaviour
{

    private GameManager m_GameManager;

	// Use this for initialization
	void Start ()
	{
	    m_GameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (m_GameManager)
        {
            m_GameManager.WinRoutine();
        }
    }
}
