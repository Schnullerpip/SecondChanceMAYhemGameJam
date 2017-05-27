using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour {

	public float holdingDistance;
	public float movementForce = 10.0f;

	private Rigidbody grabbedObject;

	public void SetGrabbedObject(Rigidbody rigidObj)
	{
		grabbedObject = rigidObj;
//		grabbedObject.isKinematic = true;
//		mass = grabbedObject.mass;
//		grabbedObject.mass = 0;
	}

	public void DropObject()
	{
//		grabbedObject.isKinematic = false;
//		grabbedObject.mass = mass;
		grabbedObject.velocity /= TimeShifter.Instance.slowmoCompensation;
		grabbedObject = null;
	}

	public bool IsHoldingObject()
	{
		return grabbedObject != null;
	}

	void Update () 
	{
		if(grabbedObject != null)
		{
			Vector3 desiredPos = transform.position + transform.forward * holdingDistance;



			grabbedObject.velocity = (desiredPos - grabbedObject.position) * 10 * TimeShifter.Instance.slowmoCompensation;
			grabbedObject.angularVelocity = Vector3.zero;
//			grabbedObject.MovePosition(transform.position + transform.forward * holdingDistance);
			grabbedObject.MoveRotation(transform.rotation);
		}
	}
}
