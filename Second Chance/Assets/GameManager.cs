using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    //needed constructor by Singleton class
    protected GameManager() {}

    //-------------MEMBER

    //the visual feedback for the player
    [SerializeField] private TimeBar m_TimeBar;

    //initial remaining time - only fetched from editor to give to the timebar
    [SerializeField] private float m_RemainingTime;

    private bool gameOver = false;


    //------------METHODS   
	// Use this for initialization
	void Start () {
        if(m_TimeBar)
            m_TimeBar.Init(m_RemainingTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(m_TimeBar)
            gameOver = m_TimeBar.IsGameOver();

        //TODO win lose condition
	    if (gameOver)
	    {
	        //end game
	    }
	}
}
