using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectGrabber))]
public class RayCastInteraction : MonoBehaviour {

	public LayerMask objectLayerMask;

	public string interactButton = "Interact";
	public float distance = 2; 

	private GameObject selectedObject = null;

	private ObjectGrabber grabber;

	void Awake () 
	{
		grabber = GetComponent<ObjectGrabber>();
	}
	
	void Update () 
	{
		RaycastHit hit;

		Ray ray = new Ray(transform.position,transform.forward);
		Debug.DrawRay(ray.origin,ray.direction * distance, Color.black);

		if(Physics.Raycast(ray, out hit, distance, objectLayerMask))
		{
            
			if(selectedObject != hit.collider.gameObject)
			{
				if(selectedObject != null)
				{
					
				}
				selectedObject = hit.collider.gameObject;
			}
		}
		else
		{
			if(selectedObject != null)
			{
				selectedObject = null;
			}
		}

		if(Input.GetButtonDown(interactButton))
		{
			if(grabber.IsHoldingObject())
			{
				grabber.DropObject();
			}
			else
			{
				if(selectedObject != null)
				{
					if(selectedObject.CompareTag("Grabable"))
					{
						grabber.SetGrabbedObject(selectedObject.GetComponent<Rigidbody>());
					}
					else if(selectedObject.CompareTag("Interactable"))
					{
                        selectedObject.GetComponent<Sender>().TriggerReceivers();
					}
				}
			}
		}
	}
}
