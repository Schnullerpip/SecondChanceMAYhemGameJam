using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour {

	public float holdingDistance;
	public float movementForce = 10.0f;

	private Rigidbody grabbedObject;


	public Rigidbody GetGrabbedObject()
	{
		return grabbedObject;
	}

	public void SetGrabbedObject(Rigidbody rigidObj)
	{
		grabbedObject = rigidObj;
	}

	public void DropObject()
	{
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
			grabbedObject.transform.rotation = Quaternion.RotateTowards(grabbedObject.transform.rotation,transform.rotation, 720*Time.unscaledDeltaTime);
		}
	}
}
