using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMounting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(!this.enabled)
		{
			return;
		}

		if(other.CompareTag("Grabable"))
		{
			LaserMirror mirror = other.GetComponent<LaserMirror>();
			if(mirror != null)
			{
				Transform t = other.transform.parent;

				ObjectGrabber grabber = GameObject.FindObjectOfType<ObjectGrabber>();
				if(grabber.GetGrabbedObject() != null && grabber.GetGrabbedObject().transform == t)
				{
					grabber.DropObject();
				}

				mirror.isReflective = false;

				t.gameObject.layer = 0;
				t.SetParent(this.transform);

				StartCoroutine(Attach(t,mirror));

				t.GetComponent<Rigidbody>().isKinematic = true;

				this.enabled = false;
			}
		}
	}

	IEnumerator Attach(Transform trans, LaserMirror mirror)
	{
		Vector3 desiredPos = new Vector3(0,0,-.28f);
		Quaternion desiredRot = Quaternion.Euler(0,180,0);

		while(Vector3.Distance(trans.localPosition,desiredPos) > .01 || Quaternion.Angle(trans.localRotation,desiredRot) > .01)
		{
			trans.localPosition = Vector3.MoveTowards(trans.localPosition,desiredPos,4*Time.deltaTime);
			trans.localRotation = Quaternion.RotateTowards(trans.localRotation,desiredRot,900*Time.deltaTime);
			yield return null;
		}

		mirror.isReflective = true;
	}
}
