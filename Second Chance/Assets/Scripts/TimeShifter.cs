using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShifter : Singleton<TimeShifter> {
	
	protected TimeShifter () {} // guarantee this will be always a singleton only - can't use the constructor!

	public float slomoSpeed = 0.1f;

	public float transitionSpeed = 1f;

	public float slowmoCompensation = 1;
	[Range(0,1)]
	public float slowmoCompensationFactor = 0.75f;

	private Coroutine coroutine = null;
	private float startFixedDeltaTime;

	public UnityEngine.Audio.AudioMixerGroup slowDownMixerGroup;

	void Awake()
	{
		startFixedDeltaTime = Time.fixedDeltaTime;
	}

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
			Time.timeScale -= transitionSpeed * Time.unscaledDeltaTime;
			AdjustSloMo();
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = desiredTimescale;
		AdjustSloMo();
	}

	IEnumerator SpeedingUp()
	{

		float desiredTimescale = 1.0f;

		while(Time.timeScale < desiredTimescale)
		{
			Time.timeScale += transitionSpeed * Time.unscaledDeltaTime;
			AdjustSloMo();
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = desiredTimescale;
		AdjustSloMo();
	}

	void AdjustSloMo()
	{
		Time.fixedDeltaTime = startFixedDeltaTime * Time.timeScale;
		slowDownMixerGroup.audioMixer.SetFloat("pitch",Time.timeScale);
		slowmoCompensation = Mathf.Lerp(1, (1/Time.timeScale)*slowmoCompensationFactor, Mathf.InverseLerp(1,slomoSpeed,Time.timeScale));
	}
}
