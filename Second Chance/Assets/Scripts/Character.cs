using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public bool isAlive = true;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;
	private Animator animator;

	void Awake()
	{
		fpsController = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		animator = GetComponent<Animator>();
	}

	public void Die()
	{
        print("Player Died!");
		animator.SetTrigger("die");
		isAlive = false;	
		fpsController.enabled = false;
	}
}
