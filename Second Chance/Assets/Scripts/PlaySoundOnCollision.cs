using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnCollision : MonoBehaviour {

	public List<AudioClip> clips;
	public float deltaPitch = 0.3f;

	private AudioSource audioSource;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision col)
	{
		audioSource.pitch = 1 + Random.Range(-deltaPitch,deltaPitch);
		audioSource.PlayOneShot(clips[Random.Range(0,clips.Count)]);
	}
}
