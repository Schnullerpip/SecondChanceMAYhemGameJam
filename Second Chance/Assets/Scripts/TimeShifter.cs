using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShifter : Singleton<TimeShifter> {
	
	protected TimeShifter () {} // guarantee this will be always a singleton only - can't use the constructor!

	public float slomoSpeed = 0.1f;

	public float transitionSpeed = 1f;

	public float slowmoCompensation = 1;

	private Coroutine coroutine = null;

	public UnityEngine.Audio.AudioMixerGroup slowDownMixerGroup;

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
		if(coroutine != null)
		{
			StopCoroutine(coroutine);
		}
		coroutine = StartCoroutine(SlowingDown());
	}

	public void SpeedUp()
	{
		if(coroutine != null)
		{
			StopCoroutine(coroutine);
		}		
		coroutine = StartCoroutine(SpeedingUp());
	}

	IEnumerator SlowingDown()
	{

		float desiredTimescale = slomoSpeed;

		while(Time.timeScale > desiredTimescale)
		{
			slowDownMixerGroup.audioMixer.SetFloat("pitch",Time.timeScale);
			Time.timeScale -= transitionSpeed * Time.unscaledDeltaTime;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			slowmoCompensation = 1 / Time.timeScale;
			yield return new WaitForEndOfFrame();
		}

		slowDownMixerGroup.audioMixer.SetFloat("pitch",Time.timeScale);
		Time.timeScale = desiredTimescale;
	}

	IEnumerator SpeedingUp()
	{

		float desiredTimescale = 1.0f;

		while(Time.timeScale < desiredTimescale)
		{
			slowDownMixerGroup.audioMixer.SetFloat("pitch",Time.timeScale);
			Time.timeScale += transitionSpeed * Time.unscaledDeltaTime;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			slowmoCompensation = 1 / Time.timeScale;
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = desiredTimescale;
		slowDownMixerGroup.audioMixer.SetFloat("pitch",Time.timeScale);

	}
}
