using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : AReceiver
{

    //time remaining
    private Text m_Text;
    private float m_RemainingTime;

	// Use this for initialization
	void Start ()
	{
	    m_Text = gameObject.GetComponentInChildren<Text>();
	}

    public void Init(float initial_remaining_time)
    {
        m_RemainingTime = initial_remaining_time;
    }

    //returns true if time is up!
	public bool IsGameOver ()
	{
        //not counting if first receive ddnt come yet
	    if (ReceivedNTimes() > 0)
	    {
            //calculate new remaining tiem
            m_RemainingTime -= Time.deltaTime*1000;
	    }

	    float seconds = 0, millis = 0;

        //separate into seconds and milliseconds, so it can be drawn on the canvas in the format -> ss:mm
	    seconds = m_RemainingTime/1000.0f;
	    millis =  m_RemainingTime % 1000.0f;
	    if (seconds < 0) seconds = 0;


        //write on the canvas
	    m_Text.text = "" + (int)seconds + ":" + (int)millis;

        //if time is up -> gameover -> return true
	    if (millis <= 0 && seconds == 0)
	    {
	        m_Text.text = "0:0";
            return true;
	    }
	    return false;
	}

    protected override void ReceiverBehaviour()
    {
        if (ReceivedNTimes() == 2)
        {  
            TimeShifter.Instance.SpeedUp();
            Destroy(this);
        }
    }
}
