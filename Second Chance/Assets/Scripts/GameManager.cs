using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    //needed constructor by Singleton class
    protected GameManager() {}

    public AReceiver bla;




    //-------------MEMBER

    //the visual feedback for the player
    [SerializeField] private TimeBar m_TimeBar;

    //initial remaining time - only fetched from editor to give to the timebar
    [SerializeField] private float m_RemainingTime;

    private bool gameOver = false;
    private float restart_time;

    //------------METHODS   
	// Use this for initialization
	void Start () {
        if(m_TimeBar)
            m_TimeBar.Init(m_RemainingTime);
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (Input.GetKeyDown("space"))
	    {
	        bla.ActOnReceive();
	    }

        if(m_TimeBar && !gameOver)
            gameOver = m_TimeBar.IsGameOver();

        //TODO win lose condition
	    if (gameOver)
	    {
            //end game
	        if (SceneManager.sceneCount < 2)
	        {
	            restart_time = Time.time + 4;
	            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
	        }

            if (Time.time >= restart_time)
            {
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
