using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public bool isAlive = true;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;
	private Animator animator;
	private AudioSource audioSource;

	public AudioClip deathSFX;

	void Awake()
	{
		fpsController = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	public void Die()
	{
		if(isAlive)
		{
			//print("Player Died!");
			animator.SetTrigger("die");
			isAlive = false;	
			fpsController.enabled = false;
			GetComponentInChildren<ObjectGrabber>().DropObject();
			audioSource.PlayOneShot(deathSFX);
		}
	}
}
