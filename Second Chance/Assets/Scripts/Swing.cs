using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

	public float speed = 2;
	public float amount = 10;
	[Range(0,Mathf.PI)]
	public float offset = 0;

	public Axis axis;

	private AudioSource audioSource;

	public enum Axis 
	{
		X,Y,Z
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = speed / 6.4f;
		audioSource.time += offset / 8;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 euler = transform.localRotation.eulerAngles;

		switch (axis) {
		case Axis.X:
			euler.x = Mathf.Sin(Time.time * speed + offset);
			break;
		case Axis.Y:
			euler.y = Mathf.Sin(Time.time * speed + offset);
			break;
		case Axis.Z:
			euler.z = Mathf.Sin(Time.time * speed + offset);
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}

		transform.localRotation = Quaternion.Euler(euler * amount);

	}
}
