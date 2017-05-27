using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSender : MonoBehaviour {

	private LineRenderer lineRenderer;
	private List<Vector3> vertices;

	public ParticleSystem particles;

	public float pulseSpeed = 20f;
	public float deltaPulse = 0.05f;

	private float startWidth;

	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer>();
		vertices = new List<Vector3>();
		startWidth = lineRenderer.widthMultiplier;
	}
	
	void Update () 
	{
		RaycastHit hit;
		Vector3 direction = transform.forward;
		Vector3 position = transform.position;

		while(Physics.Raycast(position,direction,out hit, 1000))
		{
			vertices.Add(hit.point);

			//Mirrors and other grabable stuff
			if(hit.collider.CompareTag("Grabable"))
			{
				LaserMirror mirror = hit.collider.GetComponent<LaserMirror>();
				if(mirror != null)
				{
					particles.transform.position = hit.point;
					particles.transform.rotation = Quaternion.LookRotation(Vector3.Reflect(direction, hit.normal));
				}
			}

			//walls, player, laserreceiver and everything else
			else
			{
				particles.transform.position = hit.point;
				particles.transform.rotation = Quaternion.LookRotation(Vector3.Reflect(direction, hit.normal));

				if(hit.collider.CompareTag("LaserReceiver"))
				{
					hit.collider.GetComponent<Sender>().TriggerReceivers();
				}
				else if(hit.collider.CompareTag("Player"))
				{
					hit.collider.GetComponent<Character>().Die();
				}

				break;

			}

			position = hit.point;
			direction = Vector3.Reflect(direction, hit.normal);
		}

		lineRenderer.widthMultiplier = startWidth + Mathf.Sin(Time.time * pulseSpeed) * 0.5f * deltaPulse;


		vertices.Insert(0,transform.position);
		lineRenderer.enabled = true;

		lineRenderer.positionCount = vertices.Count;
		lineRenderer.SetPositions(vertices.ToArray());

		vertices.Clear();
	}
}
