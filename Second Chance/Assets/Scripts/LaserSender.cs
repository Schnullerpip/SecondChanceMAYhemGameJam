using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSender : MonoBehaviour {

	private LineRenderer lineRenderer;
	private List<Vector3> vertices;

	public ParticleSystem particles;

	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer>();
		vertices = new List<Vector3>();
	}
	
	void Update () 
	{
		RaycastHit hit;
		Vector3 direction = transform.forward;
		Vector3 position = transform.position;

		while(Physics.Raycast(position,direction,out hit, 1000))
		{
			vertices.Add(hit.point);
			if(!hit.collider.CompareTag("Mirror"))
			{
				particles.transform.position = hit.point;
				particles.transform.rotation = Quaternion.LookRotation(Vector3.Reflect(direction, hit.normal));

				if(hit.collider.CompareTag("LaserReceiver"))
				{
					hit.collider.GetComponent<Sender>().TriggerReceivers();
				}

				break;
			}
			position = hit.point;
			direction = Vector3.Reflect(direction, hit.normal);
		}


		vertices.Insert(0,transform.position);
		lineRenderer.enabled = true;

		lineRenderer.positionCount = vertices.Count;
		lineRenderer.SetPositions(vertices.ToArray());

		vertices.Clear();
	}
}
