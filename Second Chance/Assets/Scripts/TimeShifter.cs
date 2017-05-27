using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShifter : Singleton<TimeShifter> {
	
	protected TimeShifter () {} // guarantee this will be always a singleton only - can't use the constructor!

	public float slowDownFactor = 0.1f;

	public float transitionSpeed = 0.1f;

	public float slowmoCompensation = 1;

	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			SlowDown();
		}
		if(Input.GetKeyDown(KeyCode.O))
		{
			SpeedUp();
		}
	}

	public void SlowDown()
	{
		StartCoroutine(SlowingDown());
	}

	public void SpeedUp()
	{
		StartCoroutine(SpeedingUp());
	}

	IEnumerator SlowingDown()
	{
		float desiredTimescale = Time.timeScale * slowDownFactor;

		while(Time.timeScale > desiredTimescale)
		{
			Time.timeScale -= transitionSpeed * Time.unscaledDeltaTime;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			slowmoCompensation = 1 / Time.timeScale;
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = desiredTimescale;
	}

	IEnumerator SpeedingUp()
	{
		float desiredTimescale = 1.0f;

		while(Time.timeScale < desiredTimescale)
		{
			Time.timeScale += transitionSpeed * Time.unscaledDeltaTime;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			slowmoCompensation = 1 / Time.timeScale;
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = desiredTimescale;
	}
}
