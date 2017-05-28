using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {

	public bool onCollision = true;
	public bool onTrigger = true;

    private void OnCollisionEnter(Collision collision)
    { 
		if(!onCollision)
			return;
		
		print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().Die();
        }
    }

	private void OnTriggerEnter(Collider collider)
	{ 
		if(!onTrigger)
			return;

		if (collider.gameObject.CompareTag("Player"))
		{
			collider.gameObject.GetComponent<Character>().Die();
		}
	}
}
