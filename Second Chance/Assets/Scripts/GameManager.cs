using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    //needed constructor by Singleton class
    protected GameManager() {}




    //-------------MEMBER

    //the visual feedback for the player
    private TimeBar m_TimeBar;

    //initial remaining time - only fetched from editor to give to the timebar
    [SerializeField] private float m_RemainingTime;

    private bool ran_out_of_time = false, player_is_alive = true;
    private float restart_time;

    private Character m_Character;

    //------------METHODS   
	// Use this for initialization
	void Start ()
	{
	    m_TimeBar = FindObjectOfType<TimeBar>();
        if(m_TimeBar)
            m_TimeBar.Init(m_RemainingTime);

	    m_Character = FindObjectOfType<Character>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(m_TimeBar && !ran_out_of_time)
            ran_out_of_time = m_TimeBar.IsGameOver();

	    if (m_Character != null)
	        player_is_alive = m_Character.isAlive;

	    if (ran_out_of_time || !player_is_alive)
	    {

            //end game
	        if (SceneManager.sceneCount < 2)
	        {
	            restart_time = Time.unscaledTime + 1;
	            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
	        }

            if (Time.unscaledTime >= restart_time)
            {
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
