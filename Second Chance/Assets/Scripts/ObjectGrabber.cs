using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour {

	public float holdingDistance;
	public float throwingVelocity = 10;

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
		if(grabbedObject != null)
		{
			grabbedObject.velocity /= TimeShifter.Instance.slowmoCompensation;
			grabbedObject.velocity = Vector3.ClampMagnitude(grabbedObject.velocity,throwingVelocity);
			grabbedObject = null;
		}
	}

	public bool IsHoldingObject()
	{
		return grabbedObject != null;
	}

	void Update () 
	{
		if(grabbedObject != null)
		{

			if(Input.GetButtonDown("Fire1"))
			{
				grabbedObject.velocity = transform.forward * throwingVelocity * TimeShifter.Instance.slowmoCompensation;
				DropObject();
				return;
			}

			Vector3 desiredPos = transform.position + transform.forward * holdingDistance;

			grabbedObject.velocity = (desiredPos - grabbedObject.position) * 10 * TimeShifter.Instance.slowmoCompensation;
			grabbedObject.angularVelocity = Vector3.zero;
			grabbedObject.transform.rotation = Quaternion.RotateTowards(grabbedObject.transform.rotation,transform.rotation, 720*Time.unscaledDeltaTime);
		}
	}
}
